using System.ComponentModel.DataAnnotations;

namespace newLife.Models
{
    public class CoverTyper
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cover Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
