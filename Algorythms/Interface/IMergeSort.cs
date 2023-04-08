using OwnWebApiTest.Models;

namespace OwnWebApiTest.Algorythms.Interface
{
    public interface IMergeSort
    {
        public DataSetResponse Sort(int[] array, int left, int right);
    }
}