using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface ICategoryService
    {
        SearchResult<List<Category>> GetCategoryList();
        SearchResult<Category> GetCategory(int id);
        SearchResult<Category> AddCategory(Category model);
        SearchResult<int> DeleteCategory(int id);
        SearchResult<Category> EditCategory(int id, Category model);
    }
}
