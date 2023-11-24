using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public  class OrderItemViewModel
    {
        public int id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string UnitPrice { get; set; }
    }

    public class OrderItemInsertModel
    {
        [Required(ErrorMessage = "Please Enter Orderid...!")]
        public int OrderId { get; set; }
    
        [Required(ErrorMessage = "Please Enter ProductID...!")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please Enter Quantity...!")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please Enter UnitPrice...!")]
        public string UnitPrice { get; set; }
    }

    public class OrderItemUpdateModel : OrderItemInsertModel 
    {
        public int id { get; set; }
    }
}
