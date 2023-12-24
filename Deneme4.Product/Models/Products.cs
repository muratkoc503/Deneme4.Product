using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deneme4.Product.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("ListPrice")]
        public float ListPrice { get; set; }
    }
}
