using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface IProductService
    {
        SearchResult<List<Product>> GetProductList();
        SearchResult<Product> GetProduct(int id);
        SearchResult<Product> AddProduct(Product model);
        SearchResult<int> DeleteProduct(int id);
        SearchResult<Product> EditProduct(int id, Product model);
    }
}
