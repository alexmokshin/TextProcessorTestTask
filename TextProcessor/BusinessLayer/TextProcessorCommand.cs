using System;
using System.Collections.Generic;
using System.Linq;
using TextProcessor.DatabaseModel;
using System.IO;

namespace TextProcessor.BusinessLayer
{
    class TextProcessorCommand
    {
        //static string COMMAND { get; set; }
        readonly Char[] SEPARATORS = new Char[] { ' ', ',', '.', '!', '?', '-', '\n', '"', '(', ')', '[', ']', '*', '\'', ':' };
        public DatabaseAccess dbaccess;

        public TextProcessorCommand()
        {
            dbaccess = new DatabaseAccess();
        }

        public Dictionary<string, decimal> FillDictionaryFromTextFile(string[] massString)
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
                            dictionary.Add(item, Math.Round(frequency, 18));
                    }
                }
            }


            return dictionary;
        }

        public string[] GetStringArrayFromTextFile (string text_file_path)
        {
            string file_text_string = null;
            if (File.Exists(@text_file_path))
            {
                using (var stream = new StreamReader(@text_file_path))
                {
                    file_text_string = stream.ReadToEnd();
                }
                return file_text_string.Split(SEPARATORS); 
            }
            else
            {
                Console.WriteLine("Файл по данному пути не найден. Пожалуйста, проверьте путь");
                return null;
            }

        }

        public void AddWordFrequencyDictionaryIntoDatabase(string text_file_path)
        {
            var stringMass = GetStringArrayFromTextFile(text_file_path);
            var dictionary_to_fill = FillDictionaryFromTextFile(stringMass);
            dbaccess.FillDatabaseDictionary(dictionary_to_fill);
        }

        public void DeleteDictionaryFromDatabase()
        {
            Console.WriteLine("Выполняю удаление словаря");
            dbaccess.DeleteDictionaryFromDatabase();
            
        }

        public string[] GetTopFrequencyWords(string input_word)
        {
            return dbaccess.GetTopWordsFromDictionary(input_word);
        }
    }
}
