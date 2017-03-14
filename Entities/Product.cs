using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        [Key]
        [Display(Name = "Référence")]
        public int Reference { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Prix")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Catégorie")]
        public string Category { get; set; }
        [Display(Name = "Date de validité")]
        public DateTime ValidityDate{ get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }

    }
}
