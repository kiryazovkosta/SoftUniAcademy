namespace Hospital
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());

            int doctors = 7;
            int successPatients = 0;
            int failedpatients = 0;
            for (int dayIndex = 1; dayIndex <= period; dayIndex++)
            {
                int patients = int.Parse(Console.ReadLine());
                if (dayIndex % 3 == 0)
                {
                    if (failedpatients > successPatients)
                    {
                        doctors++;
                    }
                }

                if (doctors >= patients)
                {
                    successPatients += patients;
                }
                else
                {
                    successPatients += doctors;
                    failedpatients += patients - doctors;
                }
            }

            Console.WriteLine($"Treated patients: {successPatients}.");
            Console.WriteLine($"Untreated patients: {failedpatients}.");
        }
    }
}
