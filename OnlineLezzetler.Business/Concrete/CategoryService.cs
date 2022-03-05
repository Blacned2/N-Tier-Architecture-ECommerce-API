using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLezzetler.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly OnlineLezzetlerContext _context;
        public CategoryService(OnlineLezzetlerContext context)
        {
            this._context = context;
        }


        public SearchResult<Category> AddCategory(Category model)
        {
            SearchResult<Category> searchResult = new SearchResult<Category>();

            var result = (from u in _context.Categories
                          where u.CategoryID == model.CategoryID
                          select u).FirstOrDefault();
            if (result == null)
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
                searchResult.ResultObject = model;

                searchResult.ResultMessage = String.Empty;
                searchResult.ResultType = ResultType.Success;
            }
            else
            {
                searchResult.ResultMessage = "Bu kategori daha once eklenmistir lutfen yeniden deneyiniz";
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = result;
            }
            return searchResult;

        }

        public SearchResult<int> DeleteCategory(int id)
        {
            SearchResult<int> searchResult = new SearchResult<int>();

            var result = (from u in _context.Categories
                          where u.CategoryID == id
                          select u).FirstOrDefault();

            if (result != null)
            {
                _context.Categories.Remove(result);
                _context.SaveChanges();

                searchResult.ResultMessage = String.Empty;
                searchResult.ResultType = ResultType.Success;
                searchResult.ResultObject = 0;
            }
            else
            {
                searchResult.ResultMessage = "Hatali kategori numarasi !";
                searchResult.ResultObject = id;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<Category> EditCategory(int id, Category model)
        {
            SearchResult<Category> searchResult = new SearchResult<Category>();

            var result = (from u in _context.Categories
                          where u.CategoryID == id
                          select u).FirstOrDefault();

            if(result != null)
            {
                result.CategoryName = model.CategoryName;
                _context.Update(result);
                _context.SaveChanges();

                searchResult.ResultMessage= String.Empty;
                searchResult.ResultObject = result;
                searchResult.ResultType = ResultType.Success;
            }
            else
            {
                searchResult.ResultMessage = "Hatali kategori numarasi";
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = result;
            }
            return searchResult;
            

        }

        public SearchResult<Category> GetCategory(int id)
        {
            SearchResult<Category> searchResult = new SearchResult<Category>();

            var result = (from u in _context.Categories
                          where u.CategoryID == id
                          select u).FirstOrDefault();

            if(result != null)
            {
                searchResult.ResultObject = result;
                searchResult.ResultMessage = String.Empty;
                searchResult.ResultType= ResultType.Success;
            }
            else
            {
                searchResult.ResultMessage = "Hatali kategori numarasi !";
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = null;
            }
            return searchResult;

        }

        public SearchResult<List<Category>> GetCategoryList()
        {
            SearchResult<List<Category>> searchResult = new SearchResult<List<Category>>();

            var results = (from u in _context.Categories
                           select u).ToList();

            if(results.Count > 0)
            {
                searchResult.ResultObject = results;
                searchResult.ResultMessage= String.Empty;
                searchResult.ResultType = ResultType.Success ;
            }
            else
            {
                searchResult.ResultMessage = "Bu kategoride hicbir veri bulunmamaktadir";
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = null;
            }
            return searchResult;
        }
    }
}
