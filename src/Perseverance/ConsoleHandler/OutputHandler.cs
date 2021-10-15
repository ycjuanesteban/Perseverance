using System;

namespace Perseverance.ConsoleHandler
{
    public static class OutputHandler
    {

        public static void ShowResults(string[] results)
        {
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
