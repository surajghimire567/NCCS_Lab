using Microsoft.AspNetCore.Mvc;
using NCCS_Lab_MVC.Models;

namespace NCCS_Lab_MVC.Controllers.Api
{
    // Q16: Web API Controller returning JSON
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsApiController : ControllerBase
    {
        // Static in-memory list acting as a simple data store for the demo
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Keyboard", Price = 1500 },
            new Product { Id = 2, Name = "Mouse", Price = 800 }
        };

        // GET api/productsapi
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok(products); // 200 + JSON array
        }

        // GET api/productsapi/1
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST api/productsapi
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product newProduct)
        {
            newProduct.Id = products.Count + 1;
            products.Add(newProduct);
            // 201 Created + Location header pointing to the Get(id) action
            return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
        }
    }
}
