using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessor.DatabaseModel;

namespace TextProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string word_to_complete = "1test";
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
                string[] test = dac.getTopWordsFromDictionary(word_to_complete);
                foreach(var t in test)
                {
                    Console.WriteLine(t);
                }
            }
            
        }
        public static Dictionary<string, decimal> FillDictionary(string[] massString)
        {
            decimal frequency = 0M;
            Console.WriteLine("Парсинг текста");
            var dictionary = new Dictionary<string, decimal>();
            if (massString.Length > 0 && massString != null)
            {
                foreach (var item in massString)
                {
                    if (item.Length > 3 && item.Length <= 15)
                    {
                        frequency = massString.Count(t => t == item) / Convert.ToDecimal(massString.Length);
                        if (!dictionary.ContainsKey(item))
                            dictionary.Add(item, Math.Round(frequency,18));
                    }
                }
            }
            return dictionary;

        }
    }
}
