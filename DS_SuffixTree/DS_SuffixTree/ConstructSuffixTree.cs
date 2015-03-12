using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_SuffixTree
{
    public class ConstructSuffixTree
    {
        public static string[] GetAllSuffixesOFT(string t)
        {
            int size = t.Length;
            string[] suffixes = new string[size + 1];
            for (int i = size, j = 0; i >= 0; i--, j++)
            {
                suffixes[i] = t.Substring(j);
                suffixes[i] = suffixes[i] + "$";

            }
            return suffixes;
        }

        public static string[] SortStringArray(String[] stringArray)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                for (int j = i + 1; j < stringArray.Length; j++)
                {
                    if (stringArray[j].CompareTo(stringArray[i]) < 0)
                    {
                        String temp = stringArray[j];
                        stringArray[j] = stringArray[i];
                        stringArray[i] = temp;
                    }
                }
            }
            return stringArray;
        }

        /// <summary>
        /// This is an mLogn algo to find the match index using suffix array.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <param name="sortedSuffixes"></param>
        /// <returns></returns>
        public static int GetPatternMatch(String text, String pattern, String[] sortedSuffixes)
        {
            int l = 0, r = text.Length;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                int res = MatchPatternToSuffix(pattern, sortedSuffixes[mid]);

                if (res == 0)
                    return mid;
                else if (res < 0)
                {
                    r = mid - 1;
                }
                else if (res > 0)
                {
                    l = mid + 1;
                }
            }
            return 0;
        }

        public static int MatchPatternToSuffix(String pattern, String suffix)
        {
            char[] patternChar = pattern.ToCharArray();
            char[] suffixChar = suffix.ToCharArray();

            for (int i = 0; i < patternChar.Length; i++)
            {
                if (suffixChar[i] == '$')
                    return 1;    

                if (patternChar[i] > suffixChar[i])
                    return 1;
                else if (patternChar[i] < suffixChar[i])
                    return -1;

            }
            return 0;
        }
    }
}
