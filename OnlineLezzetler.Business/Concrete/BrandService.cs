using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLezzetler.Business.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly OnlineLezzetlerContext _context;
        public BrandService(OnlineLezzetlerContext context)
        {
            this._context = context;
        }
        public SearchResult<Brand> AddBrand(Brand model)
        {
            SearchResult<Brand> searchResult = new SearchResult<Brand>();

            var result = (from u in _context.Brands
                          where u.BrandID == model.BrandID
                          select u).FirstOrDefault();
            if (result == null)
            {
                _context.Brands.Add(model);
                _context.SaveChanges();
                searchResult.ResultObject = model;

                searchResult.ResultMessage = String.Empty;
                searchResult.ResultType = ResultType.Success;
            }
            else
            {
                searchResult.ResultMessage = "Bu marka daha once eklenmistir lutfen yeniden deneyiniz";
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = result;
            }
            return searchResult;
        }

        public SearchResult<int> DeleteBrand(int id)
        {
            SearchResult<int> searchResult = new SearchResult<int>();

            var result = (from u in _context.Brands
                          where u.BrandID == id
                          select u).FirstOrDefault();

            if (result != null)
            {
                _context.Brands.Remove(result);
                _context.SaveChanges();

                searchResult.ResultMessage = String.Empty;
                searchResult.ResultType = ResultType.Success;
                searchResult.ResultObject = 0;
            }
            else
            {
                searchResult.ResultMessage = "Hatali marka numarasi !";
                searchResult.ResultObject = id;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<Brand> EditBrand(int id, Brand model)
        {
            SearchResult<Brand> searchResult = new SearchResult<Brand>();

            var result = (from u in _context.Brands
                          where u.BrandID == id
                          select u).FirstOrDefault();

            if (result != null)
            {
                result.BrandName = model.BrandName;
                result.BrandAddress = model.BrandAddress;
                _context.Update(result);
                _context.SaveChanges();

                searchResult.ResultMessage = String.Empty;
                searchResult.ResultObject = result;
                searchResult.ResultType = ResultType.Success;
            }
            else
            {
                searchResult.ResultMessage = "Hatali marka numarasi";
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = result;
            }
            return searchResult;
        }

        public SearchResult<Brand> GetBrand(int id)
        {
            SearchResult<Brand> searchResult = new SearchResult<Brand>();

            var result = (from u in _context.Brands
                          where u.BrandID == id
                          select u).FirstOrDefault();

            if (result != null)
            {
                searchResult.ResultObject = result;
                searchResult.ResultMessage = String.Empty;
                searchResult.ResultType = ResultType.Success;
            }
            else
            {
                searchResult.ResultMessage = "Hatali marka numarasi !";
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = null;
            }
            return searchResult;
        }

        public SearchResult<List<Brand>> GetBrandList()
        {
            SearchResult<List<Brand>> searchResult = new SearchResult<List<Brand>>();

            var results = (from u in _context.Brands
                           select u).ToList();

            if (results.Count > 0)
            {
                searchResult.ResultObject = results;
                searchResult.ResultMessage = String.Empty;
                searchResult.ResultType = ResultType.Success;
            }
            else
            {
                searchResult.ResultMessage = "Bu markanin hicbir verisi bulunmamaktadir";
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = null;
            }
            return searchResult;
        }
    }
}
