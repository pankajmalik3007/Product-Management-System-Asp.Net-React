using Domain.Models;
using Domain.ViewModels;
using Infrastructure.Repositories;
using Infrastructure.Services.Custome.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custome.CategoryServices
{
    public class CategoryServices : ICategoryService
    {
        #region Private Variables
        private readonly IRepository<Category> _student;
       
        public CategoryServices(IRepository<Category> student)
        {
            _student = student;
        }
        #endregion


        #region GetAll
        public async Task<ICollection<CategoryViewModel>> GetAll()
        {
            ICollection<CategoryViewModel> studentViewModels = new List<CategoryViewModel>();

            ICollection<Category> students = await _student.GetAll();

            foreach (Category student in students)
            {
                CategoryViewModel viewModel = new()
                {
                    id = student.id,
                    CategoryName = student.CategoryName
                };
                studentViewModels.Add(viewModel);
            }
            return studentViewModels;
        }
        #endregion

        #region GetById
        public async Task<CategoryViewModel> GetById(int id)
        {
            var result = await _student.GetById(id);
            if (result == null)
            {
                return null;
            }
            else
            {
                CategoryViewModel viewModel = new()
                {
                    id = result.id,
                    CategoryName = result.CategoryName
                };
                return viewModel;
            }
        }
        #endregion

        #region GetByName
        public async Task<CategoryViewModel> GetByName(string name)
        {
            var result = await _student.GetByName(name);
            if (result == null)
            {
                return null;
            }
            else
            {
                CategoryViewModel viewModel = new()
                {
                   id = result.id,
                   CategoryName = result.CategoryName
                };
                return viewModel;
            }
        }
        #endregion

        #region GetLast
        public Category GetLast()
        {
            return _student.GetLast();
        }
        #endregion

        #region Insert
        public Task<bool> Insert(CategoryInsertModel StudentInsertModel)
        {
            Category student = new()
            {
              CategoryName = StudentInsertModel.CategoryName
            };
            return _student.Insert(student);
        }

        #endregion

        #region Update

        public async Task<bool> Update(CategoryUpdateModel StudentUpdateModel)
        {
            Category student = await _student.GetById(StudentUpdateModel.id);
            if (student != null)
            {
                student.CategoryName = StudentUpdateModel.CategoryName;

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
        public async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                Category student = await _student.GetById(id);
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
        /*public async Task<bool> Delete(int id)
        {
            if (id == null)
            {
                Category student = await _student.GetById(id);
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
        }*/

        #endregion

        #region Find
        public Task<Category> Find(Expression<Func<Category, bool>> match)
        {
            return _student.Find(match);
        }
        #endregion

    }
}
