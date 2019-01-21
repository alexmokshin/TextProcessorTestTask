using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessor.BusinessLayer;

namespace TextProcessor.BusinessLayer
{
    class CommandLineController
    {
        string COMMAND { get; set; }
        string TEXT_FILE_PATH { get; set; }
        TextProcessorCommand _processorCommand = new TextProcessorCommand();

        public CommandLineController(string[] args_command)
        {
            switch(args_command.Length)
            {
                case 1:
                    COMMAND = args_command[0].ToUpper();
                    break;
                case 2:
                    COMMAND = args_command[0].ToUpper();
                    TEXT_FILE_PATH = args_command[1];
                    break;
                default:
                    break;

            }
        }
        public void SwitchCommand()
        {
            
            switch (COMMAND)
            {
                case "CREATE":
                    _processorCommand.AddWordFrequencyDictionaryIntoDatabase(TEXT_FILE_PATH);
                    break;
                case "ADD":
                    _processorCommand.AddWordFrequencyDictionaryIntoDatabase(TEXT_FILE_PATH);
                    break;
                case "DELETE":
                    _processorCommand.DeleteDictionaryFromDatabase();
                    break;
                default:
                    Console.WriteLine("Команда не распознана");
                    break;
            }
        }

        public string[] GetTopWords(string input_word)
        {
            return _processorCommand.GetTopFrequencyWords(input_word);
        }
    }
}
