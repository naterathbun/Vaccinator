using System;

namespace Vaccinator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RiteAid Vaccine Appointment Search");            
            Console.WriteLine("Western Pennsylvania / Ohio Border ");
            Console.WriteLine("Locations with Available Appointments");
            Console.WriteLine("=====================================");
            
            var appointmentFinder = new AppointmentFinder();
            appointmentFinder.FindAppointmentStatus();

            Console.ReadLine();
        }
    }
}