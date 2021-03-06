﻿using System;
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
                try
                {
                    commandLine.SwitchCommand();
                    Console.WriteLine("Нажмите кнопку для выхода из программы");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                string input_word = "";
                Console.WriteLine("Введите слово для автодополнения. Для выхода - введите пустую строку");
                do
                {
                    try
                    {
                        input_word = Console.ReadLine();
                        var t = commandLine.GetTopWords(input_word);
                        if (t.Length != 0)
                        {
                            foreach (var item in t)
                                Console.WriteLine(item);
                        }
                        else
                            Console.WriteLine("Слов в словаре не найдено");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (!String.IsNullOrWhiteSpace(input_word))
                ;
            }

            
            
        }
    }
}
