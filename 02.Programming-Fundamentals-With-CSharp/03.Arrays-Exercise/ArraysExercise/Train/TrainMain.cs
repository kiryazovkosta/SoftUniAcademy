namespace Train
{
    using System;
    public class TrainMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(n)));
            int[] peoples = new int[n];
            long peoplesCount = 0;
            for (int i = 0; i < peoples.Length; i++)
            {
                int p = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(p)));
                peoples[i] = p;
                peoplesCount += p;
            }

            Console.WriteLine(string.Join(" ", peoples));
            Console.WriteLine(peoplesCount);
        }
    }
}
