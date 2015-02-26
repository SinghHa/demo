using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_RadixSort
{
    class Program
    {
        static void Main(string[] args)
        {

            RadixSort();
        }

        private static void RadixSort()
        {
        RESTARTLABEL:
            Console.Clear();
            int lengthOfArray;


            // Get length of Array
            System.Console.WriteLine("Enter the length of Array:");
            Int32.TryParse(System.Console.ReadLine().Trim(), out lengthOfArray);
            if (lengthOfArray == 0)
            {
                System.Console.WriteLine("************************************Enter valid length************************************\n\n");
                goto RESTARTLABEL;
            }

            //Get the Array
            int[] array = new int[lengthOfArray];
            System.Console.WriteLine("Enter the {0} elements of the Array:", lengthOfArray);
            for (int i = 0; i < lengthOfArray; i++)
            {
                try
                {
                    array[i] = Int32.Parse(System.Console.ReadLine().Trim());
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("************************************Invalid Input************************************\n\n");
                    System.Threading.Thread.Sleep(2000);
                    goto RESTARTLABEL;
                }
            }

            // Find the maximum number to know number of digits
            int m = getMax(array, lengthOfArray);

            // Do counting sort for every digit. Note that instead of passing digit
            // number, exp is passed. exp is 10^i where i is current digit number
            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(array, lengthOfArray, exp);

            System.Console.WriteLine("The Sorted Array is:");
            for (int i = 0; i < array.Length; i++)
            {
                System.Console.WriteLine(array[i]);

            }

            System.Console.WriteLine("Press 'y' or 'Y' to continue.\n");
            string isContinue = System.Console.ReadLine().Trim();
            if (String.Compare(isContinue, "y") == 0 || String.Compare(isContinue, "Y") == 0)
            {
                goto RESTARTLABEL;
            }
        }

        private static int getMax(int[] arr, int n)
        {
            int max = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > max)
                    max = arr[i];
            return max;
        }

        private static void countSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n]; // output array
            int[] count = Enumerable.Repeat(0, 10).ToArray();

            // Store count of occurrences in count[]
            for (int i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains actual position of
            // this digit in output[]
            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now
            // contains sorted numbers according to curent digit
            for (int i = 0; i < n; i++)
                arr[i] = output[i];
        }
    }

}
