using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessor.DatabaseModel.EF_Model;

namespace TextProcessor.DatabaseModel
{
    public class DatabaseAccess
    {
        static TextDictionaryDatabaseEntities _textDictionary;
        private List<DICTIONARY> DICTIONARies { get; set; }
        public DatabaseAccess()
        {
            _textDictionary = new TextDictionaryDatabaseEntities();
            
        }


        public void FillDatabaseDictionary(Dictionary<string, decimal> valuePairs)
        {
            foreach (var item in valuePairs)
            {
                _textDictionary.INS_WORD_FREQUENCY(item.Key, item.Value);
                
            }
            _textDictionary.SaveChanges();
        }


        public string[] getTopWordsFromDictionary(string input_word)
        {
            var returnString = _textDictionary.SEL_WORD_TOP_FREQUENCY(input_word);
            return null;
        }
    }
}
