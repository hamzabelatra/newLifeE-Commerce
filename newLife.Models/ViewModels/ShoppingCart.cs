using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newLife.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProdcutId { get; set; }
        [ForeignKey("ProdcutId")]
        [ValidateNever]
        public Product Product { get; set; }
        [Range(1, 1000, ErrorMessage = "please enter a value between 1 and 1000")]

        public int count { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [NotMapped]
        public Double Price { get; set; }
    }
}
