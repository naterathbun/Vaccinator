using System;
using System.Threading.Tasks;

namespace Vaccinator
{
    class Program
    {        
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("RiteAid Vaccine Appointment Search");
                Console.WriteLine("Western Pennsylvania / Ohio Border ");
                Console.WriteLine("Locations with Available Appointments");
                Console.WriteLine("=====================================");

                var appointmentFinder = new AppointmentFinder();
                appointmentFinder.FindAppointmentStatus();

                Console.WriteLine("\n=====================================");

                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }
    }
}