using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RadixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 100;
            int[] testArray = new int[N];
            Random r = new Random();

            for(int i = 0; i < N; i++)
            {
                testArray[i] = r.Next(1, N + 1);
            }


            // display unsorted list
            WriteLine("Unsorted: ");
            foreach (int i in testArray)
            {
                Write(i + " ");
            }
            WriteLine();

            // call sort routine        
            RadixSort(testArray, N);
            //SpecialInsertionSort(testArray, N, testArray[0], testArray[N-1]);

            // display sorted list
            WriteLine("Sorted: ");
            foreach (int i in testArray)
            {
                Write(i + " ");
            }
            WriteLine();
            ReadLine();
        }

        static void RadixSort(int[] list, int N)
            // list: the elements to be put in order
            // N: the number of elements in the list
        {
            int digitplace = 1;
            int[] result = new int[N];
            int largestNum = GetMax(list, N);

            while((largestNum / digitplace) > 0)
            {
                int[] count = new int[10];

                for(int i = 0; i < N; i++)
                {
                    count[(list[i] / digitplace) % 10] = count[(list[i] / digitplace) % 10] + 1;
                }   // end for

                for(int i = 1; i < 10; i++)
                {
                    count[i] = count[i] + count[i - 1];
                }   // end for

                for(int i = N-1; i >= 0; i--)
                {
                    result[count[(list[i] / digitplace) % 10] - 1] = list[i];
                    count[(list[i] / digitplace) % 10] = count[(list[i] / digitplace) % 10] - 1;
                }   // end for

                for(int i = 0; i < N; i++)
                {
                    list[i] = result[i];

                }   // end for

                digitplace = digitplace * 10;
            }   // end while
        }
        static int GetMax(int[] list, int N)
        {
            int max = -1;

            for(int i = 0; i <= N; i++)
            {
                if (i > max)
                {
                    max = i;
                }   // end if

            }   // end for

            return max;
        }     
    }
}
