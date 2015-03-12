using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SuffixTree
{
    class Program
    {
        static void Main(String[] args)
        {
            String text = System.Console.ReadLine().Trim();
            String pattern = System.Console.ReadLine().Trim();
            SuffixArrayPatternSearch(text,pattern);
            System.Console.ReadLine().Trim();
        }

        private static void SuffixArrayPatternSearch(string text, String pattern)
        {

            String[] suffixes = ConstructSuffixTree.GetAllSuffixesOFT(text);
            String[] sortedSuffixes = ConstructSuffixTree.SortStringArray(suffixes);
            int matchLocation = ConstructSuffixTree.GetPatternMatch(text, pattern, sortedSuffixes);
        }
    }
}
