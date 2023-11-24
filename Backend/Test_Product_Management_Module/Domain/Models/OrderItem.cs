using Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderItem : BaseEntityClass
    {

        [Required(ErrorMessage = "Please Enter OrderId...!")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please Enter ProductId...!")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please Enter Quantity...!")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please Enter UnitPrice...!")]
        public string UnitPrice { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
