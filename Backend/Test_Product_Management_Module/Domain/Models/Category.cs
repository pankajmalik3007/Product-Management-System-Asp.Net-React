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
    public  class Category : BaseEntityClass
    {
        [Required(ErrorMessage = "Enter CategoryName ...!")]
        [Display(Name = "CategoryName")]
        [Column(TypeName = "Varchar(50)")]
        public string CategoryName { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
