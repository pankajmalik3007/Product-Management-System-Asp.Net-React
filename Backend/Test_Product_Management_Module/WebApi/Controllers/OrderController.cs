using Domain.ViewModels;
using Infrastructure.Services.Custome.OrderItemservices;
using Infrastructure.Services.Custome.OrderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Route("GetAllOrder")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _orderService.GetAll();
            if (result == null)
                return BadRequest("No Records Found, Please Try Again After Adding them...!");
            return Ok(result);
        }

        [Route("GetOrder")]
        [HttpGet]
        public async Task<IActionResult> GetCategory(int Id)
        {
            if (Id != null)
            {
                var result = await _orderService.GetById(Id);
                if (result == null)
                    return BadRequest("No Records Found, Please Try Again After Adding them...!");
                return Ok(result);
            }
            else
                return NotFound("Invalid Order Id, Please Entering a Valid One...!");

        }
        [Route("InsertOrder")]
        [HttpPost]
        public async Task<IActionResult> InsertCategory(OredrInsertModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.Insert(categoryModel);
                if (result == true)
                    return Ok("Order Inserted Successfully...!");
                else
                    return BadRequest("Something Went Wrong, Order Is Not Inserted, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Order Information, Please Entering a Valid One...!");

        }

        [Route("UpdateOrder")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(OrderUpadteModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.Update(categoryModel);
                if (result == true)
                    return Ok(categoryModel);
                else
                    return BadRequest("Something Went Wrong, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Order Information, Please Entering a Valid One...!");
        }

        [Route("DeleteOrder")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int Id)
        {
            if (Id != null)
            {
                var result = await _orderService.Delete(Id);
                if (result == true)
                    return Ok("Order Deleted SUccessfully...!");
                else
                    return BadRequest("Order is not deleted, Please Try again later...!");
            }
            else return BadRequest("Id not found");
            
        }
    }
}
