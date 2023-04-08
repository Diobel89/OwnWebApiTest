using Microsoft.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace OwnWebApiTest.Models
{
    public class Unsorted
    {
        public int[] IntArray { get; set; }
        public int SortChoice { get; set; }
    }
}
