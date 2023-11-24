using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Domain.ViewModels.ProductViewModels;

namespace Infrastructure.Services.Custome.ProductServices
{
    public  interface IProductService
    {
        Task<ICollection<ProductViewModels>> GetAll();
        Task<ProductViewModels> GetById(int id);
        Task<ProductViewModels> GetByName(string name);
        Product GetLast();
        Task<bool> Insert(ProductInsertModel CourseInsertModel);
        Task<bool> Update(ProductUpdateModel CourseUpdateModel);
        Task<bool> Delete(int id);
        Task<Product> Find(Expression<Func<Product, bool>> match);
      
    }
}
