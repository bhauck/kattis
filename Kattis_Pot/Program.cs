using System;

namespace Kattis_Pot
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            long sum = 0;

            //Console.WriteLine("The sum consists of " + Console.ReadLine() + " operands");
            Console.ReadLine();

            while ((line = Console.ReadLine()) != null)
            {
                sum += pow(Int64.Parse(line.Substring(0, line.Length - 1)), int.Parse(line.Substring(line.Length - 1, 1)));
            }
            Console.WriteLine(sum);
        }
        
        static long pow(long b, int e)
        {
            if (e == 0) return 1;

            return b * pow(b, e - 1);
        }
    }
}
