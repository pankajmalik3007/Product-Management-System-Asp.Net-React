using Domain.Models;
using Domain.ViewModels;
using Infrastructure.Context;
using Infrastructure.Services.Custome.CategoryServices;
using Infrastructure.Services.Custome.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Domain.ViewModels.ProductViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly MainDbContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger,IProductService productService, ICategoryService categoryService, MainDbContext context)
        {
            _productService = productService;
            _categoryService = categoryService;
            _context = context;
            _logger = logger;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<ActionResult<ProductViewModels>> GetAll()
        {
            _logger.LogInformation("Getting All Data ");
            var result = await _productService.GetAll();

            if (result == null)
            {
                _logger.LogWarning("Enrollement data was Not Found");
                return BadRequest("Enrollement data was Not Found");
            }
            return Ok(result);
        }
        [HttpGet(nameof(GetById))]
        public async Task<ActionResult<ProductViewModels>> GetById(int id)
        {
            _logger.LogInformation("Getting All Data By ID");
            var result = await _productService.GetById(id);
            if (result == null)
            {
                _logger.LogWarning("Enrollement data was Not Found");
                return BadRequest("Enrollement Data Was not Found");
            }
            return Ok(result);
        }

        [HttpPost(nameof(Insert))]
        public async Task<IActionResult> Insert(ProductInsertModel EnrollementInsertModel)
        {
            if (ModelState.IsValid)
            {
                Category student = await _categoryService.Find(x => x.id == EnrollementInsertModel.CategoryId);
                if (student != null)
                {
                  
                     _logger.LogInformation("Inserting Data....!");
                        var result = await _productService.Insert(EnrollementInsertModel);
                        if (result == true)
                        {
                            _logger.LogInformation("data Inserted Successfully.....!");
                            return Ok("data Inserted Successfully.....!");
                        }
                        else
                        {
                            _logger.LogWarning("Something Went Wrong.....!");
                            return BadRequest("Something Went Wrong.....!");
                        }
                    
                  
                }
                else
                    return BadRequest("Course Id is not found ");

            }
            else
            {
                return BadRequest("Model State Is not valid...!");
            }
        }
        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update(ProductUpdateModel EnrollementUpdateModel)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Updating Data...!");
                var result = await _productService.Update(EnrollementUpdateModel);
                if (result == true)
                {
                    _logger.LogInformation("Data Updated Successfully ...... !");
                    return Ok("Data Updated Successfully ...... !");
                }
                else
                {
                    _logger.LogWarning("Something Went Wrong.....!");
                    return BadRequest("Something went Wrong...... !");
                }
            }
            else
            {
                return BadRequest("ModelState is Not valid....!");
            }
        }
        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != null)
            {
                _logger.LogInformation("Deleting Data...!");
                var result = await _productService.Delete(id);
                if (result == true)
                {
                    _logger.LogInformation("Data Deleted Successfully....!");
                    return Ok("Data Deleted Successfully....!");
                }
                else
                {
                    _logger.LogWarning("Something Went Wrong.....!");
                    return BadRequest("Somthing Went Wrong......!");
                }
            }
            else
            {
                return BadRequest("Id was not Found");
            }
        }
    }
}
