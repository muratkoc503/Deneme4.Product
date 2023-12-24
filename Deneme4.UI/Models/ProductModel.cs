using System.ComponentModel.DataAnnotations;

namespace Deneme4.UI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Fill Area")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public float ListPrice { get; set; }
    }
}
