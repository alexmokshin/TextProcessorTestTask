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
            /*string word_to_complete = "1test";
            DatabaseAccess dac = new DatabaseAccess();
            StreamReader reader = new StreamReader("voina_i_mir.txt");
            string sLine = reader.ReadToEnd();
            Char[] SEPARATORS = new Char[] { ' ', ',', '.', '!', '?', '-', '\n', '"', '(', ')', '[', ']', '*', '\'', ':' };

            string[] slineMass = sLine.Split(SEPARATORS);
            var dict = FillDictionary(slineMass);
            dac.FillDatabaseDictionary(dict);
            while (!String.IsNullOrEmpty(word_to_complete))
            {
                Console.WriteLine("Начните вводить текст:");
                word_to_complete = Console.ReadLine();
                string[] test = dac.GetTopWordsFromDictionary(word_to_complete);
                foreach(var t in test)
                {
                    Console.WriteLine(t);
                }*/
            CommandLineController commandLine = new CommandLineController(args);

            if (args.Length > 0)
            {
                commandLine.SwitchCommand();
                Console.ReadLine();
            }
            else
            {
                string input_word = "";
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
