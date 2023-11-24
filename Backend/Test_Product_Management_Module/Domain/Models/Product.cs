using Domain.BaseEntity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Product : BaseEntityClass
    {
        [Required(ErrorMessage = "Enter Your ProductName ...!")]
        [Display(Name = "ProductName ")]
        [Column(TypeName = "Varchar(50)")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Enter Your Price ...!")]
        [Display(Name = "Price ")]
        [Column(TypeName = "Varchar(50)")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Enter Your StockQuantity ...!")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Enter Your CategoryId ...!")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [JsonIgnore]
        public ICollection<Cart> Carts { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
