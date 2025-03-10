using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using shop.Data;
using shop.Entities;
using shop.models;
using Microsoft.EntityFrameworkCore;



namespace shop.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("ShopOrigins")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(AddProductDto productInput)
        {
            try
            {
                // Create a Product entity from the input model
                var product = new Product
                {
                    ProductId = productInput.ProductId,
                    ProductName = productInput.ProductName,
                    ProductDescription = productInput.ProductDescription,
                    ProductImage = productInput.ProductImage,
                    ProductPrice = productInput.ProductPrice,
                    ProductQuantity = productInput.ProductQuantity
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return Ok(await _context.Products.ToListAsync());
            }
            catch (Exception ex)
            {
                // Log the exception
                // Handle other exceptions if needed
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(EditProductDto productDto)
        {
            var dbProduct = await _context.Products.FindAsync(productDto.ProductId);
            if (dbProduct == null)
            {
                return BadRequest("Product not found.");
            }

            dbProduct.ProductName = productDto.ProductName;
            dbProduct.ProductDescription = productDto.ProductDescription;
            dbProduct.ProductImage = productDto.ProductImage;
            dbProduct.ProductPrice = productDto.ProductPrice;
            dbProduct.ProductQuantity = productDto.ProductQuantity;

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }


        [HttpDelete("{ProductId}")]
        public async Task<ActionResult<List<Product>>> DeleteProducts(int ProductId)
        {
            var dbProduct = await _context.Products.FindAsync(ProductId);
            if (dbProduct == null)
            {
                return BadRequest("Product not found.");
            }

            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();

            return Ok(new { Success = true, Message = "Delete product successfully" });
        }
    }
}
