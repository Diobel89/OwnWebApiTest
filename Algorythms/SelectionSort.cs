using OwnWebApiTest.Algorythms.Interface;
using System.Diagnostics;
using OwnWebApiTest.Models;

namespace OwnWebApiTest.Algorythms
{
    public class SelectionSort : ISelectionSort
    {
        public DataSetResponse Sort(int[] array)
        {
            long time;
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            var arrayLength = array.Length;

            for (int i = 0; i < arrayLength - 1; i++)
            {
                var smallestVal = i;

                for (int j = i + 1; j < arrayLength; j++)
                {
                    if (array[j] < array[smallestVal])
                    {
                        smallestVal = j;
                    }
                }

                var tempVar = array[smallestVal];
                array[smallestVal] = array[i];
                array[i] = tempVar;
            }
            watch.Stop();
            time = watch.ElapsedTicks;
            DataSetResponse data = new DataSetResponse() { Name = "Selection Sort", Sorted = array, Time = time };
            return data;
        }
    }
}
