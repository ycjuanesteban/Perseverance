using Perseverance.Application.Services;
using Perseverance.ConsoleHandler;
using Perseverance.ConsoleHandlers;
using System;

namespace Perseverance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Perseverance");
            string fullUserInput = InputHandler.GetInstructions();

            PerseveranceService perseveranceService = new PerseveranceService(fullUserInput);

            perseveranceService.Execute();

            string[] finalResult = perseveranceService.GetFinalResult();

            OutputHandler.ShowResults(finalResult);
        }
    }
}
