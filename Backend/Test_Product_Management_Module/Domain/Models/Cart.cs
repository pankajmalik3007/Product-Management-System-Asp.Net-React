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
    public class Cart : BaseEntityClass
    {
        [Required(ErrorMessage = "Please Enter ProductID...!")]

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity...!")]

        public int Quantity { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
