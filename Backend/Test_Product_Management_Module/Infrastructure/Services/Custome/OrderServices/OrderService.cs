using Domain.Models;
using Domain.ViewModels;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Services.Custome.OrderServices
{
    public  class OrderService : IOrderService
    {
        private readonly IRepository<Order> _student;

        public OrderService(IRepository<Order> student)
        {
            _student = student;
        }
        #region GetAll
        public async Task<ICollection<OrderViewModel>> GetAll()
        {
            ICollection<OrderViewModel> studentViewModels = new List<OrderViewModel>();

            ICollection<Order> students = await _student.GetAll();

            foreach (Order student in students)
            {
                OrderViewModel viewModel = new()
                {
                    id = student.id,
                    OrderDate = student.OrderDate,
                    TotalAmount = student.TotalAmount,



                };
                studentViewModels.Add(viewModel);
            }
            return studentViewModels;
        }
      /*  public async Task<ICollection<OrderViewModel>> GetAll()
        {
            ICollection<OrderViewModel> orderViewModels = new List<OrderViewModel>();

            ICollection<Order> orders = await _student.GetAll();

            foreach (Order order in orders)
            {
                OrderViewModel viewModel = new()
                {
                    id = order.id,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    OrderItems = order.OrderItems.Select(item => new OrderItemViewModel
                    {
                        id = item.id,
                        ProductId = item.ProductId,
                        OrderId = item.OrderId,

                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    }).ToList()
                };
                orderViewModels.Add(viewModel);
            }
            return orderViewModels;
        }
*/


        #endregion

        #region GetById
        public async Task<OrderViewModel> GetById(int id)
        {
            var result = await _student.GetById(id);
            if (result == null)
            {
                return null;
            }
            else
            {
                OrderViewModel viewModel = new()
                {
                     id = result.id,
                     OrderDate= result.OrderDate,
                    TotalAmount = result.TotalAmount


                };
                return viewModel;
            }
        }
        #endregion

        #region GetByName
        public async Task<OrderViewModel> GetByName(string name)
        {
            var result = await _student.GetByName(name);
            if (result == null)
            {
                return null;
            }
            else
            {
                OrderViewModel viewModel = new()
                {
                    id = result.id,
                    OrderDate = result.OrderDate,
                    TotalAmount = result.TotalAmount

                };
                return viewModel;
            }
        }
        #endregion

        #region GetLast
        public Order GetLast()
        {
            return _student.GetLast();
        }
        #endregion

        #region Insert
        public Task<bool> Insert(OredrInsertModel StudentInsertModel)
        {
            Order student = new()
            {
               
                OrderDate = StudentInsertModel.OrderDate,
                TotalAmount = StudentInsertModel.TotalAmount
            };
            return _student.Insert(student);
        }

        #endregion

        #region Update

        public async Task<bool> Update(OrderUpadteModel StudentUpdateModel)
        {
            Order student = await _student.GetById(StudentUpdateModel.id);
            if (student != null)
            {

               
                student.OrderDate = StudentUpdateModel.OrderDate;
                student.TotalAmount = StudentUpdateModel.TotalAmount;

                var result = await _student.Update(student);
                return result;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Delete
        /* public async Task<bool> Delete(Guid id)
         {
             if (id != Guid.Empty)
             {
                 Student student = await _student.GetById(id);
                 if (student != null)
                 {
                     //Direct Declaration
                     _ = _student.Delete(student);
                     return true;
                 }
                 else
                 {
                     return false;
                 }
             }
             else
             {
                 return false;
             }
         }*/
        public async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                Order student = await _student.GetById(id);
                if (student != null)
                {
                    return await _student.Delete(student);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Find
        public Task<Order> Find(Expression<Func<Order, bool>> match)
        {
            return _student.Find(match);
        }
        #endregion

    }
}
