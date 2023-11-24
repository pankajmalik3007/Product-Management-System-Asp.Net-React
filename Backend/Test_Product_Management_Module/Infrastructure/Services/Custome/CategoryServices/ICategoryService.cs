using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custome.CategoryServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetById(int id);
        Task<CategoryViewModel> GetByName(string name);
        Category GetLast();
        Task<bool> Insert(CategoryInsertModel StudentInsertModel);
        Task<bool> Update(CategoryUpdateModel StudentUpdateModel);
        Task<bool> Delete(int id);
        Task<Category> Find(Expression<Func<Category, bool>> match);
    }
}
