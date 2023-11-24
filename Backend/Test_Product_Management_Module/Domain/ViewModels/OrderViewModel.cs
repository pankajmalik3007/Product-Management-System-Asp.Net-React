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
    public class OrderViewModel
    {
        public int id { get; set; }
        public DateTime OrderDate { get; set; }
        public string TotalAmount { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    }

    public class OredrInsertModel
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
    }

    public class OrderUpadteModel : OredrInsertModel
    {
        [Required(ErrorMessage = "Id is neccessory for updation...!")]
        public int id { get; set; }
    }
}
