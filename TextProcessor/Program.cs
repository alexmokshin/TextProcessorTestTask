using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextProcessor.DatabaseModel;
using TextProcessor.BusinessLayer;

namespace TextProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CommandLineController commandLine = new CommandLineController(args);

            if (args.Length > 0)
            {
                commandLine.SwitchCommand();
                Console.ReadLine();
            }
            else
            {
                string input_word = "";
                Console.WriteLine("Введите слово для автодополнения");
                do
                {
                    input_word = Console.ReadLine();
                    commandLine.GetTopWords(input_word);
                }
                while (!String.IsNullOrEmpty(input_word));
            }

            
            
        }
    }
}
