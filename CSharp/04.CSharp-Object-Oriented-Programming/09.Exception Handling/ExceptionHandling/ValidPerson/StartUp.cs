namespace ValidPerson
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            //IPerson person = new Person("Peter", "Johnson", 24);
            //IPerson personWithoutFirstName = new Person(null, "Johnson", 31);
            //IPerson personWithoutLastName = new Person("Jordon", string.Empty, 25);
            //IPerson personWithNegativeAge = new Person("Peter", "Miller", -1);
            //IPerson personWithTooBigAge = new Person("Sam", "Bundy", 122);
            //IPerson personWithTooBigAge = new Person("P3t3r", "Bundy", 65);
            //IPerson personWithTooBigAge = new Person("Peter", "B0ddy_", 65);

            try
            {
                IPerson personWithTooBigAge = new Person("Peter", "Boddy", 65);
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine($"Exception throw: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception throw: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception throw: {ex.Message}");
            }
        }
    }
}
