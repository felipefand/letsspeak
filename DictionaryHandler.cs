using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsSpeak
{
    internal class DictionaryHandler
    {
        private Dictionary dictionary;
        public DictionaryHandler(Dictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        public void AddWord()
        {
            Console.Clear();
            Console.WriteLine("Write the word to be added: ");
            var name = Console.ReadLine();

            Console.WriteLine("Write the definition of the word: ");
            var definition = Console.ReadLine();

            if (dictionary.Add(name, definition))
                Console.WriteLine("Word added successfully.");
            else
                Console.WriteLine("Word already exists.");

            dictionary.Save();
            Console.ReadKey();
        }

        public void RemoveWord()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Write the word to be removed: ");
            var name = Console.ReadLine();

            if (dictionary.Remove(name))
                Console.WriteLine("Word deleted successfully.");
            else
                Console.WriteLine("Word not found.");

            dictionary.Save();
            Console.ReadKey();
        }

        public void SearchWords()
        {
            Console.Clear();
            Console.WriteLine("Type in your search: ");
            var searchWord = Console.ReadLine();

            var foundWords = dictionary.GetWordList()
                .Where((w) => w.Key.Contains(searchWord, StringComparison.InvariantCultureIgnoreCase))
                .ToDictionary(w => w.Key, w => w.Value);

            Console.Clear();
            if (foundWords.Count == 0)
            {
                Console.WriteLine("No matches found.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("We have found the following word(s): \n");
            foreach (var w in foundWords)
            {
                Console.WriteLine($"{w.Key}: {w.Value}");
            }

            Console.ReadKey();
        }

        public void ExitSystem()
        {
            dictionary.Save();
            Environment.Exit(0);
        }
    }
}
