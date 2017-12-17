using RDotNet;
using System;
using System.IO;

namespace RCSharpConnectorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the R script file path: ");
                var scriptFilePath = Console.ReadLine();
                if (File.Exists(scriptFilePath))
                    ExecuteScriptFile(scriptFilePath);
                else
                    Console.WriteLine("Invalid File Path");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured: {ex.Message}");
            }
            Console.Read();
        }

        private static void ExecuteScriptFile(string scriptFilePath)
        {
            using (var en = REngine.GetInstance())
            {
                var execution = $"source('{scriptFilePath}')";
                en.Evaluate(execution);
            }
        }
    }
}
