using Domain.Models;
using Domain.ViewModels;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custome.OrderItemservices
{
    public class OrderItemService : IOrderItemService
    {
        #region Private Variables
        private readonly IRepository<OrderItem> _student;

        public OrderItemService(IRepository<OrderItem> student)
        {
            _student = student;
        }
        #endregion


        #region GetAll
        public async Task<ICollection<OrderItemViewModel>> GetAll()
        {
            ICollection<OrderItemViewModel> studentViewModels = new List<OrderItemViewModel>();

            ICollection<OrderItem> students = await _student.GetAll();

            foreach (OrderItem student in students)
            {
                OrderItemViewModel viewModel = new()
                {
                    id = student.id,
                    ProductId = student.ProductId,
                    Quantity = student.Quantity,
                    UnitPrice = student.UnitPrice,
                    OrderId = student.OrderId

                };
                studentViewModels.Add(viewModel);
            }
            return studentViewModels;
        }
        #endregion

        #region GetById
        public async Task<OrderItemViewModel> GetById(int id)
        {
            var result = await _student.GetById(id);
            if (result == null)
            {
                return null;
            }
            else
            {
                OrderItemViewModel viewModel = new()
                {
                    id = result.id,
                    ProductId = result.ProductId,
                    Quantity = result.Quantity,
                    UnitPrice = result.UnitPrice


                };
                return viewModel;
            }
        }
        #endregion

        #region GetByName
        public async Task<OrderItemViewModel> GetByName(string name)
        {
            var result = await _student.GetByName(name);
            if (result == null)
            {
                return null;
            }
            else
            {
                OrderItemViewModel viewModel = new()
                {
                    id = result.id,
                    ProductId = result.ProductId,
                    Quantity = result.Quantity,
                    UnitPrice = result.UnitPrice

                };
                return viewModel;
            }
        }
        #endregion

        #region GetLast
        public OrderItem GetLast()
        {
            return _student.GetLast();
        }
        #endregion

        #region Insert
        public Task<bool> Insert(OrderItemInsertModel StudentInsertModel)
        {
            OrderItem student = new()
            {
                OrderId = StudentInsertModel.OrderId,
                ProductId = StudentInsertModel.ProductId,
                Quantity = StudentInsertModel.Quantity,
                UnitPrice = StudentInsertModel.UnitPrice
            };
            return _student.Insert(student);
        }

        #endregion

        #region Update

        public async Task<bool> Update(OrderItemUpdateModel StudentUpdateModel)
        {
            OrderItem student = await _student.GetById(StudentUpdateModel.id);
            if (student != null)
            {

                student.ProductId = StudentUpdateModel.ProductId;
                student.Quantity = StudentUpdateModel.Quantity;
                student.UnitPrice = StudentUpdateModel.UnitPrice;

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
                OrderItem student = await _student.GetById(id);
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
        public Task<OrderItem> Find(Expression<Func<OrderItem, bool>> match)
        {
            return _student.Find(match);
        }
        #endregion

    }
}
