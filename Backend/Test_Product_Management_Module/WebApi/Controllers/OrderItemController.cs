using Domain.ViewModels;
using Infrastructure.Services.Custome.OrderItemservices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        [Route("GetAllOrderitem")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _orderItemService.GetAll();
            if (result == null)
                return BadRequest("No Records Found, Please Try Again After Adding them...!");
            return Ok(result);
        }

        [Route("GetOrderitem")]
        [HttpGet]
        public async Task<IActionResult> GetCategory(int Id)
        {
            if (Id != null)
            {
                var result = await _orderItemService.GetById(Id);
                if (result == null)
                    return BadRequest("No Records Found, Please Try Again After Adding them...!");
                return Ok(result);
            }
            else
                return NotFound("Invalid OrderItem Id, Please Entering a Valid One...!");

        }
        [Route("InsertOrderItem")]
        [HttpPost]
        public async Task<IActionResult> InsertCategory(OrderItemInsertModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderItemService.Insert(categoryModel);
                if (result == true)
                    return Ok("Category Inserted Successfully...!");
                else
                    return BadRequest("Something Went Wrong, OrderItem Is Not Inserted, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid OrderItem Information, Please Entering a Valid One...!");

        }

        [Route("UpdateOrderItem")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(OrderItemUpdateModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderItemService.Update(categoryModel);
                if (result == true)
                    return Ok(categoryModel);
                else
                    return BadRequest("Something Went Wrong, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid OrderItem Information, Please Entering a Valid One...!");
        }

        [Route("DeleteOrderItem")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var result = await _orderItemService.Delete(Id);
            if (result == true)
                return Ok("OrderItem Deleted SUccessfully...!");
            else
                return BadRequest("OrderItem is not deleted, Please Try again later...!");
        }
    }
}
