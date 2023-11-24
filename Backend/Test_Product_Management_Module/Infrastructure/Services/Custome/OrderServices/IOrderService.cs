using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custome.OrderServices
{
    public  interface IOrderService
    {
        Task<ICollection<OrderViewModel>> GetAll();
        Task<OrderViewModel> GetById(int id);
        Task<OrderViewModel> GetByName(string name);
        Order GetLast();
        Task<bool> Insert(OredrInsertModel StudentInsertModel);
        Task<bool> Update(OrderUpadteModel StudentUpdateModel);
        Task<bool> Delete(int id);
        Task<Order> Find(Expression<Func<Order, bool>> match);
    }
}
