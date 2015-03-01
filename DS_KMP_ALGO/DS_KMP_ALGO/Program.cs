using System;
using System.Linq;

namespace DS_KMP_ALGO
{
    class Program
    {
        static void Main(string[] args)
        {
            KMP();
        }

        private static void KMP()
        {
            string text, pattern;

            System.Console.WriteLine("Enter the Text");
            text = System.Console.ReadLine().Trim();
            System.Console.WriteLine("Enter the Text");
            pattern = System.Console.ReadLine().Trim();

            int lengthOfText = text.Length;
            int lengthOfPattern = pattern.Length;

            int[] LSPArray = GetLongestPrefixSuffix(pattern);
            int matchIndex = GetMatchingIndexUsingKMP(text, pattern, LSPArray);

            if (matchIndex != -1)
            {
                System.Console.WriteLine("Match Found at Index {0}", matchIndex);
            }
            else
            {
                System.Console.WriteLine("No Match Found");
            }
            System.Console.ReadLine().Trim();
                
        }

        private static int[] GetLongestPrefixSuffix(string pattern)
        {
            int i = 1, j = 0, pattenLength = pattern.Length;

            int[] LPSArray = new int[pattenLength];
            LPSArray[0] = 0;
            while (i < pattenLength)
            {
                if (pattern.ElementAt(i) == pattern.ElementAt(j))
                {
                    LPSArray[i] = j + 1;
                    i++;
                    j++;
                }
                else if (j > 0)
                {
                    j = LPSArray[j - 1];
                }
                else
                {
                    LPSArray[i] = 0;
                    i++;
                }
                string result = String.Join(", ", LPSArray.Select(x => x.ToString()).ToArray());
            }
            return LPSArray;
        }

        private static int GetMatchingIndexUsingKMP(string text, string pattern, int[] LPSArray)
        {
            int i = 0, j = 0;
            int textLength = text.Length, patternLength = pattern.Length;
            while (i < textLength)
            {
                if (text.ElementAt(i) == pattern.ElementAt(j))
                {
                    if (j == patternLength - 1)
                    {
                        return i - j;
                    }
                    else
                    {
                        i++;
                        j++;
                    }
                }
                else if (j > 0)
                    j = LPSArray[j - 1];
                else
                    i++;
            }

            return -1;
        }
    }
}
