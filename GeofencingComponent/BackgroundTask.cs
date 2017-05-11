using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.Notifications;

namespace GeofencingComponent
{
    public sealed class BackgroundTask : IBackgroundTask
    {
        private const string TaskName = "BackgroundTask";

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var monitor = GeofenceMonitor.Current;
            if(monitor.Geofences.Any())
            {
                var reports = monitor.ReadReports();
                foreach (var report in reports)
                {
                    switch (report.NewState)
                    {
                        case GeofenceState.Entered:
                            {
                                ShowToast("Careful, you entered a dangerous zone.");
                                break;
                            }
                        case GeofenceState.Exited:
                            {
                                ShowToast("You exited a dangerous zone.");
                                break;
                            }
                    }
                }
            }
        }

        private static void ShowToast(string s)
        {
            var toastXmlContent = 
                ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);

            var txtNodes = toastXmlContent.GetElementsByTagName("text");
            txtNodes[0].AppendChild(toastXmlContent.CreateTextNode(s));

            var toast = new ToastNotification(toastXmlContent);
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            toastNotifier.Show(toast);

            //TODO: Remover depois dos testes
            Debug.WriteLine("Toast: {0}", s);
        }

        public static IAsyncOperation<bool> Register()
        {
            return RegisterInternal().AsAsyncOperation();
        }

        private async static Task<bool> RegisterInternal()
        {
            if (!IsTaskRegistered())
            {
                await BackgroundExecutionManager.RequestAccessAsync();
                var builder = new BackgroundTaskBuilder()
                {
                    Name = TaskName,
                    TaskEntryPoint = typeof(BackgroundTask).FullName
                };
                var trigger = new LocationTrigger(LocationTriggerType.Geofence);
                builder.SetTrigger(trigger);
                builder.Register();
                return true;
            }
            return false;
        }

        public static void Unregister()
        {
            var entry = BackgroundTaskRegistration.AllTasks.FirstOrDefault(t => t.Value.Name == TaskName);

            if(entry.Value != null)
            {
                entry.Value.Unregister(true);
            }
        }

        public static bool IsTaskRegistered()
        {
            return BackgroundTaskRegistration.AllTasks.Any(t => t.Value.Name == TaskName);
        }
    }
}
