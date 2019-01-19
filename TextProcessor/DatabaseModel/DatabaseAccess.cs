using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessor.DatabaseModel.EF_Model;

namespace TextProcessor.DatabaseModel
{
    public class DatabaseAccess : IDatabaseManage<string[], Dictionary<string,decimal>>
    {
        private bool IsBusy { get; set; } = false;
        static TextDictionaryDatabaseEntities _textDictionary;
        private List<DICTIONARY> DICTIONARies { get; set; }
        public DatabaseAccess()
        {
            _textDictionary = new TextDictionaryDatabaseEntities();
            
        }


        public void FillDatabaseDictionary(Dictionary<string, decimal> word_dictionary)
        {
            if (!IsBusy)
            {
                Console.WriteLine("Наполнение словаря");
                IsBusy = true;
                foreach (var item in word_dictionary)
                {
                    _textDictionary.INS_WORD_FREQUENCY(item.Key, item.Value);

                }
                _textDictionary.SaveChanges();
                Console.WriteLine("Словарь заполнен");
                IsBusy = false;
            }
            else
                Console.WriteLine("Словарь наполняется. Повторите операцию позже");
        }


        public string[] GetTopWordsFromDictionary(string input_word)
        {
            var p0 = new SqlParameter("word", System.Data.SqlDbType.NVarChar, 15).Value = input_word;
            return _textDictionary.Database.SqlQuery<string>("exec dbo.SEL_WORD_TOP_FREQUENCY {0}", p0).ToArray();
        }

        public void DeleteDictionaryFromDatabase()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                _textDictionary.DeleteDictionaryFromDatabase();
                Console.WriteLine("Словарь удален");
                IsBusy = false;
            }
            else
                Console.WriteLine("База занята. Пожалуйста, повторите операцию позже");
        }
    }
}
