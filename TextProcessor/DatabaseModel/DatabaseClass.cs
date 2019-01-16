using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessor.DatabaseModel.EF_Model;

namespace TextProcessor.DatabaseModel
{
    public class DatabaseClass
    {
        private List<DICTIONARY> DICTIONARies { get; set; }
        public void FillDatabaseDictionary()
        {
            TextDictionaryDatabaseEntities textDictionary = new TextDictionaryDatabaseEntities();
            textDictionary.DICTIONARY.AddRange(DICTIONARies);
            textDictionary.SaveChanges();
        }
        public void SetDictionaryList(Dictionary<string, decimal> valuePairs)
        {
            DICTIONARies = new List<DICTIONARY>();
            
            foreach (var item in valuePairs)
            {
                
                DICTIONARies.Add(new DICTIONARY
                {
                    WORD = item.Key,
                    FREQUENCY = item.Value
                });
            }
        }
    }
}
