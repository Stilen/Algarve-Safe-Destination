using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.UI.Xaml;

namespace ADS.Classes
{
    class Geofences
    {

        public static void RegisterGeofences()
        {
            if(GeofenceMonitor.Current.Geofences.Any())
            {
                GeofenceMonitor.Current.Geofences.Clear();
            }
            /*
             * TODO:
             * Ler zonas perigosas da DB
             * e adicionar no loop abaixo
             */

            /*foreach (var location in LocationObject.GetLocationObjects())
            {
                AddFence(location.Id, location.Location);
            }*/
            var basic = new BasicGeoposition();
                basic.Latitude = 37.146134;
                basic.Longitude = -8.020631;
                var point = new Geopoint(basic);
                AddFence("test_geofence", point);                
        }

        private static void AddFence(string key, Geopoint position)
        {
            var oldFence = GeofenceMonitor.Current.Geofences.FirstOrDefault(p => p.Id == key);
            if(oldFence != null)
            {
                GeofenceMonitor.Current.Geofences.Remove(oldFence);
            }

            //TODO: ler raio
            var geocircle = new Geocircle(position.Position, 150);
            const bool singleUse = false;
            MonitoredGeofenceStates mask = 0;
            mask |= MonitoredGeofenceStates.Entered;
            mask |= MonitoredGeofenceStates.Exited;

            //TODO: aumentar o tempo do trigger
            var geofence = new Geofence(key, geocircle, mask, singleUse, TimeSpan.FromSeconds(1));
            GeofenceMonitor.Current.Geofences.Add(geofence);
        }

    }
}
