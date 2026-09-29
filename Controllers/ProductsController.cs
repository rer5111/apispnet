using Apispnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Apispnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AspSiteContext _context;

        public ProductsController(AspSiteContext context, IWebHostEnvironment environment)
        {
            _context = context;
        }

        private static ProductDTO toDTO(Product product) => new ProductDTO
        {
            IdProduct = product.IdProduct,
            Title = product.Title,
            Cost = product.Cost,
            CategoryId = product.CategoryId,
        };
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll(int page = 1, int pageSize = 10)
        {
            var products = _context.Products.OrderBy(p => p.IdProduct)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToList()
                .Select(toDTO)
                .ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.IdProduct == id);
            if (product is null) return NotFound();
            return Ok(toDTO(product));
        }

        [HttpPost]
        public IActionResult Create(CreateProductDTO dto)
        {
            var product = new Product
            {
                Title = dto.Title,
                Cost = dto.Cost,
                CategoryId = dto.CategoryId,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = product.IdProduct }, toDTO(product));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(UpdateProductDTO dto)
        {
            var product = _context.Products.FirstOrDefault(p => p.IdProduct == dto.IdProduct);
            if (product is null)
            {
                return NotFound();
            }
            product.Title = dto.Title;
            product.Cost = dto.Cost;
            product.CategoryId = dto.CategoryId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.IdProduct == id);
            if (product is null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchProduct(PatchProductDTO dto)
        {
            var product = _context.Products.FirstOrDefault(p => p.IdProduct == dto.IdProduct);
            if (product is null) { return NotFound(); }
            if (dto.Title is not null) product.Title = dto.Title;
            if (dto.Cost is not null) product.Cost = dto.Cost.Value;
            if (dto.CategoryId is not null) product.CategoryId = dto.CategoryId.Value;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
