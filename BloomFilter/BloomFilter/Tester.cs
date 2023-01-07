using System;
using System.Collections.Generic;
using System.Text;

namespace BloomFilter
{
    class Tester
    {
        static void Main(string[] args)
        {
            Func<char, int>[] list = new Func<char, int>[0];
            BloomFilterer<char> bloom = new BloomFilterer<char>(100, list);

            bloom.Insert('a');
            bloom.Insert('b');
            bloom.Insert('c');
            bloom.Insert('d');
            bloom.Insert('e');
            bloom.Insert('f');
            bloom.Insert('g');
            bloom.Insert('h');
            bloom.Insert('i');
            bloom.Insert('j');
            bloom.Insert('k');
            bloom.Insert('l');
            bloom.Insert('m');
            bloom.Insert('n');
            bloom.Insert('o');
            bloom.Insert('p');
            bloom.Insert('q');
            bloom.Insert('r');
            bloom.Insert('s');
            bloom.Insert('t');
            bloom.Insert('u');
            bloom.Insert('v');
            bloom.Insert('w');
            bloom.Insert('x');
            bloom.Insert('y');
            bloom.Insert('z');
            Console.WriteLine(bloom.ProbablyContains('a'));
            Console.WriteLine(bloom.ProbablyContains('-'));
        
        }
    }
}
