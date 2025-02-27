﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]

        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }


        [Required]
        public int Stock { get; set; }


        public string Description { get; set; }


        public string Image { get; set; }
        [NotMapped]
        public string? Categoryname { get; set; }
    }
}
