using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deneme4.Yugioh.Models
{
    [Table("Yugioh")]
    public class YugiohCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Type")]
        public string Type { get; set; }

        [Column("SubType")]
        public string? SubType { get; set; }

        [Column("Attribute")]
        public string? Attribute { get; set; }

        [Column("Level")]
        public int Level { get; set; }

        [Column("Attack")]
        public int Attack { get; set; }

        [Column("Defence")]
        public int Defence { get; set; }

        [Column("Text")]
        public string? Text { get; set; }

        [Column("Password")]
        public int Password { get; set; }
    }
}
