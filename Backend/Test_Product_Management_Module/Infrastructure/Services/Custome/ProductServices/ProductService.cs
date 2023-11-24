using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custome.ProductServices
{
    using Domain.Models;
    using Domain.ViewModels;
    using global::Infrastructure.Repositories;
  
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using static Domain.ViewModels.ProductViewModels;

    namespace Infrastructure.Services.Custom.CourseServices
    {
        public class ProductService : IProductService
        {
            #region Private Variables
            private readonly IRepository<Product> _course;
            private readonly IRepository<Category> _category;
            
            public ProductService(IRepository<Product> course, IRepository<Category> category)
            {
                _category = category;
                _course = course;

            }
            #endregion


            #region GetAll
            public async Task<ICollection<ProductViewModels>> GetAll()
            {
                ICollection<ProductViewModels> CourseViewModel = new List<ProductViewModels>();

                ICollection<Product> courses = await _course.GetAll();

                foreach (Product course in courses)
                {
                    ProductViewModels viewModel = new()
                    {
                        id = course.id,
                        ProductName = course.ProductName,
                        Price = course.Price,
                        StockQuantity = course.StockQuantity,
                        CategoryId = course.CategoryId
                    };
                    CourseViewModel.Add(viewModel);
                }
                return CourseViewModel;
            }
            #endregion

            #region GetById
            public async Task<ProductViewModels> GetById(int id)
            {
                var result = await _course.GetById(id);
                if (result == null)
                {
                    return null;
                }
                else
                {
                    ProductViewModels viewModel = new()
                    {
                        id = result.id,
                        ProductName = result.ProductName,
                        Price = result.Price,
                        StockQuantity = result.StockQuantity,
                        CategoryId = result.CategoryId
                    };
                    return viewModel;
                }
            }
            #endregion

            #region GetByName
            public async Task<ProductViewModels> GetByName(string name)
            {
                var result = await _course.GetByName(name);
                if (result == null)
                {
                    return null;
                }
                else
                {
                    ProductViewModels viewModel = new()
                    {
                        id = result.id,
                        ProductName = result.ProductName,
                        Price = result.Price,
                        StockQuantity = result.StockQuantity,
                        CategoryId = result.CategoryId
                    };
                    return viewModel;
                }
            }
            #endregion

            #region GetLast
            public Product GetLast()
            {
                return _course.GetLast();
            }
            #endregion

            #region Insert
            public async Task<bool> Insert(ProductInsertModel CourseInsertModel)
            {
              
                var cat =await _category.Find(x => x.id == CourseInsertModel.CategoryId);
                var result = await _course.Find(x => x.CategoryId == cat.id);
                if (CourseInsertModel.CategoryId == cat.id)
                {
                    Product viewModel = new()
                    {
                        ProductName = CourseInsertModel.ProductName,
                        Price = CourseInsertModel.Price,
                        StockQuantity = CourseInsertModel.StockQuantity,
                        CategoryId = CourseInsertModel.CategoryId
                    };
                    var enrollment = await _course.Insert(viewModel);
                    if(enrollment == true)
                    {

                        return true;


                    }
                    else
                        return false;
                }
                else
                    return false;
            }
                
            
            #endregion

            #region Update

            public async Task<bool> Update(ProductUpdateModel CourseUpdateModel)
            {
                Product course = await _course.GetById(CourseUpdateModel.id);
                if (course != null)
                {
                    course.ProductName = CourseUpdateModel.ProductName;
                    course.Price = CourseUpdateModel.Price;
                    course.StockQuantity = CourseUpdateModel.StockQuantity;
                    course.CategoryId = CourseUpdateModel.CategoryId;

                    var result = await _course.Update(course);
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
                    Product student = await _course.GetById(id);
                    if (student != null)
                    {
                        return await _course.Delete(student);
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
            public Task<Product> Find(Expression<Func<Product, bool>> match)
            {
                return _course.Find(match);
            }
            #endregion

        }
    }
}
