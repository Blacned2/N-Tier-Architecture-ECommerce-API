using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Data.Models;
using System.Collections.Generic;

namespace OnlineLezzetler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            this._brandService = brandService;
        }

        [HttpGet, Route("BrandList")]
        public ActionResult<List<Brand>> GetBrandList()
        {
            var BrandList = _brandService.GetBrandList();
            return BrandList.ResultObject;
        }

        [HttpGet, Route("Brand/{id}")]
        public ActionResult<Brand> GetBrand(int id)
        {
            var Brand = _brandService.GetBrand(id);
            return Brand.ResultObject;
        }

        [HttpPost, Route("Brand")]
        public ActionResult PostBrand(Brand model)
        {
            var result = _brandService.AddBrand(model);
            return Ok();
        }

        [HttpDelete, Route("BrandDelete/{id}")]
        public ActionResult DeleteBrand(int id)
        {
            var result = _brandService.DeleteBrand(id);
            return Ok();
        }

        [HttpPut, Route("BrandEdit/{id}")]
        public ActionResult EditBrand(int id, Brand model)
        {
            var result = _brandService.EditBrand(id, model);
            return Ok();
        }
    }
}
