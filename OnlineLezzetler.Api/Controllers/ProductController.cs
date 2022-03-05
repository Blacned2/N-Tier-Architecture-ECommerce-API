using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Data;
using OnlineLezzetler.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLezzetler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        //private readonly OnlineLezzetlerContext _context;
        public ProductController(IProductService productService/*, OnlineLezzetlerContext context*/)
        {
            //this._context = context;
            this._productService = productService;
            #region Dummy Data Generator
            //for (int i = 1; i < 10; i++)
            //{
            //    var dummy = (from u in _context.Brands
            //                 where u.BrandID == i
            //                 select u).FirstOrDefault();
            //    dummy.BrandAddress = Faker.Country.Name();
            //    _context.Update(dummy);
            //    _context.SaveChanges();
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    var dummy = new Brand();
            //    dummy.BrandName = Faker.Name.First();
            //    _context.Brands.Add(dummy);
            //    _context.SaveChanges();
            //}

            //var dummy = (from u in _context.Brands
            //             where u.BrandID == 10
            //             select u).FirstOrDefault();
            //dummy.BrandAddress = Faker.Address.City();
            //_context.Update(dummy);
            //_context.SaveChanges();

            //for (int i = 0; i < 10; i++)
            //{
            //    var dummy = new Product();
            //    dummy.ProductName = Faker.Name.First();
            //    dummy.Description = Faker.Finance.Ticker();
            //    dummy.UnitPrice = Faker.RandomNumber.Next(1, 100);
            //    dummy.BrandID = Faker.RandomNumber.Next(1, 10);
            //    dummy.CategoryID = Faker.RandomNumber.Next(1, 10);

            //    _context.Products.Add(dummy);
            //    _context.SaveChanges();
            //}
            #endregion
        }

        [HttpGet,Route("ProductList")]
        public ActionResult<List<Product>> GetProductList()
        {
            var ProductListe = _productService.GetProductList();
            return ProductListe.ResultObject;
        }

        [HttpGet,Route("Product/{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            return product.ResultObject;
        }
        
        [HttpPost,Route("Product")]
        public ActionResult PostProduct(Product model)
        {
            var result = _productService.AddProduct(model);
            return Ok();
        }

        [HttpDelete,Route("ProductDelete/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpPut,Route("ProductEdit/{id}")]
        public ActionResult EditProduct(int id,Product model)
        {
            var result = _productService.EditProduct(id,model);
            return Ok();
        }
    }
}
