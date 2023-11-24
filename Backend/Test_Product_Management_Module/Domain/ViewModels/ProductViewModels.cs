using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.ViewModels
{
    public class ProductViewModels 
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public int StockQuantity { get; set; }


        public int CategoryId { get; set; }
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public class ProductInsertModel 
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
        }

        public class ProductUpdateModel : ProductInsertModel
        {
            public int id { get; set; }
        }
    }
}
