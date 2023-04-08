using OwnWebApiTest.Algorythms.Interface;
using System.Diagnostics;
using OwnWebApiTest.Models;

namespace OwnWebApiTest.Algorythms
{
    public class InsertionSort : IInsertionSort
    {
        public DataSetResponse Sort(int[] array)
        {
            long time;
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            for (int i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var flag = 0;

                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (key < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = key;
                    }
                    else flag = 1;
                }
            }
            watch.Stop();
            time = watch.ElapsedTicks;

            DataSetResponse data = new DataSetResponse() { Name = "Insertion Sort", Sorted = array, Time = time };
            return data;
        }
    }
}
