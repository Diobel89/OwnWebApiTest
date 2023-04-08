using OwnWebApiTest.Models;

namespace OwnWebApiTest.Algorythms.Interface
{
    public interface IQuickSort
    {
        public DataSetResponse Sort(int[] array, int leftIndex, int rightIndex);
    }
}