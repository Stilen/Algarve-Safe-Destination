﻿

#pragma checksum "C:\Users\Tomás\Source\Workspaces\LES_1415_g02\ADS_Solution\ADS\Pages\Contactos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8181E605CDA69CABFDA89A28095B3762"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADS.Pages
{
    partial class Contactos : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 19 "..\..\..\Pages\Contactos.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.map1_Loaded;
                 #line default
                 #line hidden
                #line 19 "..\..\..\Pages\Contactos.xaml"
                ((global::Windows.UI.Xaml.Controls.Maps.MapControl)(target)).MapTapped += this.map1_MapTapped;
                 #line default
                 #line hidden
                #line 19 "..\..\..\Pages\Contactos.xaml"
                ((global::Windows.UI.Xaml.Controls.Maps.MapControl)(target)).ZoomLevelChanged += this.map1_ZoomLevelChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 36 "..\..\..\Pages\Contactos.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.MyLocationButton_Tapped;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 44 "..\..\..\Pages\Contactos.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.phone_stack_Tapped;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 49 "..\..\..\Pages\Contactos.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.email_stack_Tapped;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 25 "..\..\..\Pages\Contactos.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.StackPanel_Tapped;
                 #line default
                 #line hidden
                #line 25 "..\..\..\Pages\Contactos.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Holding += this.MapItemsStack_Holding;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


