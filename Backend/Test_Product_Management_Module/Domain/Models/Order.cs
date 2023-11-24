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
    public  class Order : BaseEntityClass
    {

        [Required(ErrorMessage = "Enter Your Name ...!")]
        [Display(Name = "Enrollment Date")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = ("Please Enter Valid Date Format ...!"))]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Enter Your Credits ...!")]
        [Display(Name = "Instructor Credits")]
        [Column(TypeName = "Varchar(50)")]
        public string TotalAmount { get; set; }
        [JsonIgnore]
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
