using Domain.Models;
using Domain.ViewModels;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custome.CartServices
{
    public  class CartService : ICartService
    {
        #region Private Variables
        private readonly IRepository<Cart> _student;

        public CartService(IRepository<Cart> student)
        {
            _student = student;
        }
        #endregion


        #region GetAll
        public async Task<ICollection<CartViewModel>> GetAll()
        {
            ICollection<CartViewModel> studentViewModels = new List<CartViewModel>();

            ICollection<Cart> students = await _student.GetAll();

            foreach (Cart student in students)
            {
                CartViewModel viewModel = new()
                {
                    id = student.id,
                    ProductId = student.ProductId,
                    Quantity = student.Quantity
                   
                };
                studentViewModels.Add(viewModel);
            }
            return studentViewModels;
        }
        
        #endregion

        #region GetById
        public async Task<CartViewModel> GetById(int id)
        {
            var result = await _student.GetById(id);
            if (result == null)
            {
                return null;
            }
            else
            {
                CartViewModel viewModel = new()
                {
                    id = result.id,
                    ProductId = result.ProductId,
                    Quantity = result.Quantity


                };
                return viewModel;
            }
        }
        #endregion

        #region GetByName
        public async Task<CartViewModel> GetByName(string name)
        {
            var result = await _student.GetByName(name);
            if (result == null)
            {
                return null;
            }
            else
            {
                CartViewModel viewModel = new()
                {
                    id = result.id,
                    ProductId = result.ProductId, Quantity = result.Quantity
                   
                };
                return viewModel;
            }
        }
        #endregion

        #region GetLast
        public Cart GetLast()
        {
            return _student.GetLast();
        }
        #endregion

        #region Insert
        public Task<bool> Insert(CartInsertModel StudentInsertModel)
        {
            Cart student = new()
            {
              ProductId = StudentInsertModel.ProductId,
              Quantity = StudentInsertModel.Quantity
            };
            return _student.Insert(student);
        }



        #endregion

        #region Update

        public async Task<bool> Update(CartUpdateModel StudentUpdateModel)
        {
            Cart student = await _student.GetById(StudentUpdateModel.id);
            if (student != null)
            {
                
                student.ProductId = StudentUpdateModel.ProductId;
                student.Quantity = StudentUpdateModel.Quantity;

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
                Cart student = await _student.GetById(id);
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
        public Task<Cart> Find(Expression<Func<Cart, bool>> match)
        {
            return _student.Find(match);
        }
        #endregion

    }
}
