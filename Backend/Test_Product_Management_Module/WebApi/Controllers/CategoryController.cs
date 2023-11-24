﻿using Domain.ViewModels;
using Infrastructure.Services.Custome.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _serviceCategory;
        public CategoryController(ICategoryService serviceCategory) 
        { _serviceCategory = serviceCategory; }

        [Route("GetAllCategory")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _serviceCategory.GetAll();
            if (result == null)
                return BadRequest("No Records Found, Please Try Again After Adding them...!");
            return Ok(result);
        }

        [Route("GetCategory")]
        [HttpGet]
        public async Task<IActionResult> GetCategory(int Id)
        {
            if (Id != null)
            {
                var result = await _serviceCategory.GetById(Id);
                if (result == null)
                    return BadRequest("No Records Found, Please Try Again After Adding them...!");
                return Ok(result);
            }
            else
                return NotFound("Invalid Category Id, Please Entering a Valid One...!");

        }
        [Route("InsertCategory")]
        [HttpPost]
        public async Task<IActionResult> InsertCategory(CategoryInsertModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceCategory.Insert(categoryModel);
                if (result == true)
                    return Ok("Category Inserted Successfully...!");
                else
                    return BadRequest("Something Went Wrong, Category Is Not Inserted, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Category Information, Please Entering a Valid One...!");

        }

        [Route("UpdateCategory")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceCategory.Update(categoryModel);
                if (result == true)
                    return Ok(categoryModel);
                else
                    return BadRequest("Something Went Wrong, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Category Information, Please Entering a Valid One...!");
        }

        [Route("DeleteCategory")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var result = await _serviceCategory.Delete(Id);
            if (result == true)
                return Ok("Category Deleted SUccessfully...!");
            else
                return BadRequest("Category is not deleted, Please Try again later...!");
        }
    }
}
