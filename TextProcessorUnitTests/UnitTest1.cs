﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextProcessor;
using TextProcessor.DatabaseModel;
using System.IO;
using System.Collections;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace TextProcessorUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DatabaseClass database = new DatabaseClass();
            StreamReader reader = new StreamReader("chehov.txt");
            string sLine = reader.ReadToEnd();
            Char[] SEPARATORS = new Char[] { ' ', ',', '.', '!', '?', '-', '\n', '"', '(', ')', '[',']','*','\'',':'};
            
            string[] slineMass = sLine.Split(SEPARATORS);
            var dict = FillDictionary(slineMass);
           // var moqSet = new Mock<DbSet<>>
            DatabaseClass dc = new DatabaseClass();
            dc.SetDictionaryList(dict);
            dc.FillDatabaseDictionary();
            
        }
        [TestMethod]
        public string[] input_text_array(string text_file_path)
        {

        }
        public Dictionary<string,decimal> FillDictionary(string[] massString)
        {
            decimal frequency = 0M;
            var dictionary = new Dictionary<string, decimal>();
            if (massString.Length > 0 && massString != null)
            {
                foreach (var item in massString)
                {
                    if (item.Length > 3)
                    {
                        frequency = massString.Count(t => t == item) / Convert.ToDecimal(massString.Length);
                        if (!dictionary.ContainsKey(item))
                            dictionary.Add(item, frequency);
                    }
                }
            }
            return dictionary;

        }
    }
}
