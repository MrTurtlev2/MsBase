using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace MsBase.Models
{
    public class MsBaseModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "Length grater than 3 required")]
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }

        [Required]
        public bool Avilable { get; set; }

        [Range(1, 100)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

    }
}
