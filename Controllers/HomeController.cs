using E_Commerce.Database;
using E_Commerce.DTO;
using E_Commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public HomeController( ApplicationDbContext db)
        {
            _db = db;
        }
        //Create 
        [HttpPost]
       public async Task<ActionResult> CreateProduct ([FromBody] CreateUpdatedto dto )
        {
            var newProduct = new Products()
            {
                Name = dto.Name,    
                Category=dto.Category,
                Price= dto.Price,   
                Image=dto.Image,
                Description=dto.Description,
                Rating=dto.Rating
            };
            await _db.Products.AddAsync(newProduct);
            await _db.SaveChangesAsync();
            return Ok("Product Saved Succefully");
        }
        //Read Product
        [HttpGet]
        public async Task<ActionResult<List<Products>>> Read()
        {
            var Products = await _db.Products.ToListAsync();
            return Ok(Products);
        }

        //ReadSpecific Product
        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> ReadSpecific(long Id )
        {
            // if there is a problem u will find the reson here in id
          var SpecialProduct = await _db.Products.FirstOrDefaultAsync(x => x.Id == Id); 
            if(SpecialProduct is null)
            {
                return NotFound("Product NotFound");
            }
            return Ok(SpecialProduct);

        }
        //Update Product
        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] long Id , [FromBody] CreateUpdatedto dto)
        {
            var UpdateProduct = await _db.Products.FirstOrDefaultAsync(q => q.Id == Id);
                if  (UpdateProduct is null )
            {
                return NotFound("Product Not Found ");
            }
                UpdateProduct.Name = dto.Name;
                UpdateProduct.Description = dto.Description;
                UpdateProduct.Rating = dto.Rating;
                UpdateProduct.Price = dto.Price;
                UpdateProduct.Image = dto.Image;
                UpdateProduct.Category = dto.Category;
                await _db.SaveChangesAsync();
            return Ok("Products Update Succefully");
        }
        //Delete
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteProduct ([FromRoute] long Id)
        {
            var Product = await _db.Products.FirstOrDefaultAsync(q=> q.Id == Id);

            if( Product is null )
            {
                return NotFound("Product Not Found ");
            }
             _db.Products.Remove(Product);
            await _db.SaveChangesAsync();
            return Ok("Product Deleted Succefully");
        }

    }
}
