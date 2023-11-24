using Domain.ViewModels;
using Infrastructure.Services.Custome.CartServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [Route("GetAllCart")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _cartService.GetAll();
            if (result == null)
                return BadRequest("No Records Found, Please Try Again After Adding them...!");
            return Ok(result);
        }

        [Route("GetCart")]
        [HttpGet]
        public async Task<IActionResult> GetCategory(int Id)
        {
            if (Id != null)
            {
                var result = await _cartService.GetById(Id);
                if (result == null)
                    return BadRequest("No Records Found, Please Try Again After Adding them...!");
                return Ok(result);
            }
            else
                return NotFound("Invalid Category Id, Please Entering a Valid One...!");

        }
        [Route("Insertcart")]
        [HttpPost]
        public async Task<IActionResult> InsertCategory(CartInsertModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _cartService.Insert(categoryModel);
                if (result == true)
                    return Ok("Category Inserted Successfully...!");
                else
                    return BadRequest("Something Went Wrong, Category Is Not Inserted, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Category Information, Please Entering a Valid One...!");

        }

        [Route("UpdateCart")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CartUpdateModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _cartService.Update(categoryModel);
                if (result == true)
                    return Ok(categoryModel);
                else
                    return BadRequest("Something Went Wrong, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Category Information, Please Entering a Valid One...!");
        }

        [Route("DeleteCart")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var result = await _cartService.Delete(Id);
            if (result == true)
                return Ok("Category Deleted SUccessfully...!");
            else
                return BadRequest("Category is not deleted, Please Try again later...!");
        }
    }
}
