using System;
using Windows.Devices.Geolocation;

namespace ADS.Classes
{
    public class ZonaPerigosa
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public String Nome { get; set; }
        public Geocircle circulo { get; set; }
        

        public ZonaPerigosa (String Nome, double Raio, double Latitude, double Longitude)
        {
            this.Nome = Nome;
            
            var position = new BasicGeoposition();
            position.Latitude = Latitude;
            position.Longitude = Longitude;
            position.Altitude = 0;

            var point = new Geopoint(position);
            circulo = new Geocircle(position, Raio);
        }
    }
}
