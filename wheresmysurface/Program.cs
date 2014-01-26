using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Sensors;
using Windows.Foundation;
using System.Net;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using System.Net; 

namespace wheresmysurface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Geolocator loc = new Geolocator();
            try
            {
                loc.DesiredAccuracy = PositionAccuracy.High;
                loc.GetGeopositionAsync(TimeSpan.FromMinutes(5.0), TimeSpan.FromMinutes(5.0));
                loc.PositionChanged += loc_PositionChanged;
            }
            catch (System.UnauthorizedAccessException)
            {

            }
            Application.Run();
        }

        static void loc_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Console.WriteLine(args.Position.Coordinate.Latitude + "," + args.Position.Coordinate.Longitude);

            WebClient client = new WebClient();
            client.OpenReadAsync(new Uri("http://jaxbot.me/wheresmysurface.php?report=1&lat=" + args.Position.Coordinate.Latitude + "&long=" + args.Position.Coordinate.Longitude));
            client.OpenReadCompleted += (o, e) =>
            {
                Environment.Exit(0);
            };
        }
    }
}
