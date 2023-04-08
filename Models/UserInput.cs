using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OwnWebApiTest.Models
{
    public class UserInput
    {
        [Required, Range(0, int.MaxValue)]
        public int HowManyInts { get; set; }
    }
}
