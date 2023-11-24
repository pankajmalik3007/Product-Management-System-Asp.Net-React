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
    public class CategoryViewModel
    {
        public int id { get; set; }
        public string CategoryName { get; set; }

       /* public List<Product> products { get; set; } = new List<Product>();*/
    }

    public class CategoryInsertModel
    {
        [Required(ErrorMessage = "Enter CategoryName ...!")]
        [Display(Name = "CategoryName")]
        [Column(TypeName = "Varchar(50)")]
        public string CategoryName { get; set; }
    }

    public class CategoryUpdateModel : CategoryInsertModel 
    {
        public int id { get; set; }
    }

}
