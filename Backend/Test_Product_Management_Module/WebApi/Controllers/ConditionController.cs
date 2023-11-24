using Domain.Models;
using Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ConditionController(MainDbContext context)
        {
            _context = context;
        }
        // Condition 1: Get details by Product Name
        /*  [HttpGet("GetDetailsByProductName/{productName}")]
          public async Task<ActionResult<IEnumerable<Product>>> GetDetailsByProductName(string productName)
          {
              var products = await _context.Products
                  .Where(p => p.ProductName.ToLower() == productName.ToLower())
                  .Include(p => p.Category)
                  .ToListAsync();

              if (products == null || !products.Any())
              {
                  return NotFound();
              }

              return Ok(products);
          }*/
        [HttpGet("GetDetailsByProductName/{productName}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetDetailsByProductName(string productName)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 32 
            };

            var products = await _context.Products
                .Where(p => p.ProductName.ToLower() == productName.ToLower())
                .Include(p => p.Category)
                .Include(p => p.OrderItems)
                    .ThenInclude(oi => oi.Order)
                .ToListAsync();

            if (products == null || !products.Any())
            {
                return NotFound();
            }

            var serializedProducts = JsonSerializer.Serialize(products, options);

            return Ok(serializedProducts);
        }


        // Condition 2: Get Product by OrderId
        // Condition 2: Get Product by OrderId
        [HttpGet("GetProductByOrderId/{orderId}")]
        public async Task<ActionResult<Product>> GetProductByOrderId(int orderId)
        {
            var product = await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .Include(oi => oi.Product)  // Move Include before Select
                .ThenInclude(p => p.Category)
                .Select(oi => oi.Product)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        // Condition 3: Get Category Name by CartId
        [HttpGet("GetCategoryNameByCartId/{cartId}")]
        public async Task<ActionResult<string>> GetCategoryNameByCartId(int cartId)
        {
            var categoryName = await _context.Carts
                .Where(c => c.id == cartId)
                .Select(c => c.Product.Category.CategoryName)
                .FirstOrDefaultAsync();

            if (categoryName == null)
            {
                return NotFound();
            }

            return Ok(categoryName);
        }
    }
}
