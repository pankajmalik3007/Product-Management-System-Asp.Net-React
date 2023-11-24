using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custome.CartServices
{
    public  interface ICartService
    {
        Task<ICollection<CartViewModel>> GetAll();
        Task<CartViewModel> GetById(int id);
        Task<CartViewModel> GetByName(string name);
        Cart GetLast();
        Task<bool> Insert(CartInsertModel StudentInsertModel);
        Task<bool> Update(CartUpdateModel StudentUpdateModel);
        Task<bool> Delete(int id);
        Task<Cart> Find(Expression<Func<Cart, bool>> match);
    }
}
