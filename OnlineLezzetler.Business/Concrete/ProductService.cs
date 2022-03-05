using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLezzetler.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly OnlineLezzetlerContext _context;
        public ProductService(OnlineLezzetlerContext context)
        {
            this._context = context;
        }

        public SearchResult<Product> AddProduct(Product model)
        {
            SearchResult<Product> searchResult = new SearchResult<Product>();

            var result = (from u in _context.Products
                          where u.ProductID == model.ProductID
                          select u).FirstOrDefault();
            if (result == null)
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                searchResult.ResultObject = model;

                searchResult.ResultMessage = String.Empty;
                searchResult.ResultType = ResultType.Success;
            }
            else
            {
                searchResult.ResultMessage = "Bu urun daha once eklenmistir lutfen yeniden deneyiniz";
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = result;
            }
            return searchResult;
        }

        public SearchResult<int> DeleteProduct(int id)
        {
            SearchResult<int> searchResult = new SearchResult<int>();
            try
            {
                var result = (from u in _context.Products
                              where u.ProductID == id
                              select u).FirstOrDefault();

                if(result != null)
                {
                    _context.Remove(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = 1;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Silinecek urun bulunamadi";
                    searchResult.ResultObject = 0;
                    searchResult.ResultType = ResultType.Error;
                }
            }
            catch (Exception exp)
            {
                searchResult.ResultType=ResultType.Error;
                searchResult.ResultMessage=exp.Message;
            }
            return searchResult;
        }

        public SearchResult<Product> EditProduct(int id, Product model)
        {
            SearchResult<Product> searchResult = new SearchResult<Product>();

            try
            {
                var result = (from u in _context.Products
                              where u.ProductID == id
                              select u).FirstOrDefault();

                if (result != null)
                {
                    result.ProductName = model.ProductName;
                    result.UnitPrice = model.UnitPrice;
                    result.Category = model.Category;
                    result.Brand = model.Brand;
                    result.Description = model.Description;

                    _context.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = result;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Hatali urun numarasi";
                    searchResult.ResultType = ResultType.Error;
                    searchResult.ResultObject = result;
                }
            }
            catch (Exception exp)
            {
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultMessage  = exp.Message;
            }


            return searchResult;

        }

        public SearchResult<Product> GetProduct(int id)
        {
            SearchResult<Product> searchResult = new SearchResult<Product>();

            try
            {
                var result = (from u in _context.Products
                              where u.ProductID == id
                              select u).FirstOrDefault();

                if (result != null)
                {
                    searchResult.ResultObject = result;
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Hatali urun numarasi !";
                    searchResult.ResultType = ResultType.Error;
                    searchResult.ResultObject = null;
                }
            }
            catch (Exception exp)
            {
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultMessage = exp.Message;
            }

            return searchResult;
        }

        public SearchResult<List<Product>> GetProductList()
        {
            SearchResult<List<Product>> searchResult = new SearchResult<List<Product>>();

            try
            {
                var results = (from u in _context.Products
                               select u).ToList();

                if (results.Count > 0)
                {
                    searchResult.ResultObject = results;
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Urun listesinde hicbir veri bulunmamaktadir";
                    searchResult.ResultType = ResultType.Error;
                    searchResult.ResultObject = null;
                }
            }
            catch (Exception exp)
            {
                searchResult.ResultType= ResultType.Error;
                searchResult.ResultMessage = exp.Message;
            }

            return searchResult;
        }
    }
}
