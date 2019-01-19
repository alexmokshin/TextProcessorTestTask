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

        public CommandLineController(string[] args_command)
        {
            switch(args_command.Length)
            {
                case 1:
                    COMMAND = args_command[0];
                    break;
                case 2:
                    COMMAND = args_command[0];
                    TEXT_FILE_PATH = args_command[1];
                    break;
                default:
                    break;

            }
        }
        public void SwitchCommand()
        {
            TextProcessorCommand processorCommand = new TextProcessorCommand();
            switch (COMMAND)
            {
                case "Add":
                    processorCommand.AddWordFrequencyDictionaryIntoDatabase(TEXT_FILE_PATH);
                    break;
                case "Delete":
                    processorCommand.DeleteDictionaryFromDatabase();
                    break;
                default:
                    break;


            }
        }
    }
}
