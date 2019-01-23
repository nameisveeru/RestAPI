using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

namespace Module1.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        static List<Product> _products = new List<Product>()
        {
            new Product(){ ProductId = 0, ProductName = "Ford", ProductMake = "Mustang", ProductModel = "GT", ProductYear = 2015},
            new Product(){ ProductId = 1, ProductName = "Chevrolet", ProductMake = "Corvette", ProductModel = "Z06", ProductYear = 2017},
            new Product(){ ProductId = 2, ProductName = "Dodge", ProductMake = "Challenger", ProductModel = "Hellcat", ProductYear = 2016}

        };
        public IEnumerable<Product> Get()
        {
            return _products;
        }
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status202Accepted);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            _products[id] = product;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }
    }
}