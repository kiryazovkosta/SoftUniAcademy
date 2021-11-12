namespace Demos
{
    public static class DemosExtensions
    {
        public static void Main()
        {
            var valid = new List<string>()
            {
                "6101057509",
                "7907150625"
            };

            var invalid = new List<string>()
            {
                "-907150625",
                "2790715062",
                "79131506252",
                "9122150625",
                "7935150625",
                "7948150625",
                "7955150625",

            };

            try
            {
                IEgnValidator validator = new EgnValidator();
                Console.WriteLine("-------------- Valid ------------------");
                foreach (var egn in valid)
                {
                    Console.WriteLine($"{egn} => {validator.Validate(egn)}");
                }

                Console.WriteLine("------------- Invalid -----------------");
                foreach (var egn in invalid)
                {
                    Console.WriteLine($"{egn} => {validator.Validate(egn)}");
                }

                Console.WriteLine("------------ Generate -----------------");
                var generated = validator.Generate(new DateTime(1979, 7, 15), "Бургас", true);
                foreach (var egn in generated)
                {
                    Console.WriteLine($"{egn} => {validator.Validate(egn)}");
                }

                validator.Generate(DateTime.Today, string.Empty, false);
            }
            catch   (InvalidCityException cityException)
            {
                Console.WriteLine(cityException.GetType().FullName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType().Name);
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.Source);
                Console.WriteLine(exception.StackTrace);
            }

        }
    }
}