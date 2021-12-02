namespace Stealer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            var result = spy.CollectGettersAndSetters("Stealer.Hacker");
            System.Console.WriteLine(result);
        }
    }
}
