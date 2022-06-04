using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Tries
{
    class Program
    {
        static List<string> checkWords(string Word, Trie t)
        {
            return t.GetAllMatchingPrefix(Word);
        }
        static Trie allWordsTrie(Dictionary<string, string> words)
        {
            Trie toReturn = new Trie();
            foreach(string word in words.Keys)
            {
                toReturn.Insert(word);
            }
            return toReturn;
        }

        static string ProvideDef(Dictionary<string, string> words, string Word, Trie all)
        {
            bool a = words.ContainsKey(Word);
            List<string> prefixSimilar = checkWords(Word.Substring(0,Word.Length-1), all);
            if (a)
            {
                return words[Word];
            }
            else
            {
                if(prefixSimilar.Count > 0)
                {
                    return $"That word doesnt have a definition. Maybe you meant {prefixSimilar[0]}: {words[prefixSimilar[0]]}";
                }
                else
                {
                    return " ";
                }
            }
        }
        static void Main(string[] args)
        {
            string words = File.ReadAllText("Dict.txt");
            Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(words);
            Trie all = allWordsTrie(dict);
            Trie t = new Trie();
            t.Insert("babe");
            t.Insert("baby");
            t.Insert("he");
            t.Insert("hey");
            t.Insert("hell");
            t.Insert("hello");
            t.Insert("heaven");
            t.Insert("havana");
            Console.WriteLine(t.Contains("h"));
            List<string> list = t.GetAllMatchingPrefix("!");
            t.Remove("he");

            string r = ProvideDef(dict, "dancd", all);
            Console.WriteLine(r);

            
        }
    }
}
