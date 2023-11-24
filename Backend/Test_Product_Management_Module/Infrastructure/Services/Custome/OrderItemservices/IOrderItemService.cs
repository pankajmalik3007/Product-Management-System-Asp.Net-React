using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custome.OrderItemservices
{
    public  interface IOrderItemService
    {
        Task<ICollection<OrderItemViewModel>> GetAll();
        Task<OrderItemViewModel> GetById(int id);
        Task<OrderItemViewModel> GetByName(string name);
        OrderItem GetLast();
        Task<bool> Insert(OrderItemInsertModel StudentInsertModel);
        Task<bool> Update(OrderItemUpdateModel StudentUpdateModel);
        Task<bool> Delete(int id);
        Task<OrderItem> Find(Expression<Func<OrderItem, bool>> match);
    }
}
