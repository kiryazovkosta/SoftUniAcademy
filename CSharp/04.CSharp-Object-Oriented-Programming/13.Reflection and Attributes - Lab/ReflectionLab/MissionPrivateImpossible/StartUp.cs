namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            var result = spy.RevealPrivateMethods("Stealer.Hacker");
            System.Console.WriteLine(result);
        }
    }
}