using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public  class CartViewModel
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CartInsertModel
    {

        [Required(ErrorMessage = "Please Enter ProductID...!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity...!")]
        public int Quantity { get; set; }
    }

    public class CartUpdateModel : CartInsertModel
    {
        public int id { get; set; }
    }
}
