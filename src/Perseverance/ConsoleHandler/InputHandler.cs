using System;
using System.Text;

namespace Perseverance.ConsoleHandlers
{
    //https://stackoverflow.com/a/24338688
    public static class InputHandler
    {
        public static string GetInstructions()
        {
            StringBuilder userInstructions = new StringBuilder();

            WelcomeMessage();

            string instructionLine;
            do
            {
                instructionLine = Console.ReadLine();
                if (instructionLine != string.Empty)
                    userInstructions.Append(instructionLine);

            } while (instructionLine != null);

            return userInstructions.ToString();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine($"Instructions:{Environment.NewLine}" +
                $"Add world size in format X Y{Environment.NewLine}" +
                $"  - Example: 5 3{Environment.NewLine}" +
                $"Add initial robot coordinates with uppercase letter{Environment.NewLine}" +
                $"  - 3 2 N{Environment.NewLine}" +
                $"Add instructions in a line (100 characters is the limit){Environment.NewLine}" +
                $"  - RFLRFLRFL{Environment.NewLine}{Environment.NewLine}" +
                $"To finish, press Ctrl + Z{Environment.NewLine}{Environment.NewLine}" +
                $"----------------------------------------------------------------------------------{Environment.NewLine}");
        }
    }
}
