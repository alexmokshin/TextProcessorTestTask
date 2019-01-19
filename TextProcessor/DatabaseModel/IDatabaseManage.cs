using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessor.DatabaseModel
{
    interface IDatabaseManage<T, D>
    {
        void FillDatabaseDictionary(D words_to_fill);
        T GetTopWordsFromDictionary(string input_word);
        void DeleteDictionaryFromDatabase();
    }
}
