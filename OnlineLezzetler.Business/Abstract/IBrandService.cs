using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface IBrandService
    {
        SearchResult<List<Brand>> GetBrandList();
        SearchResult<Brand> GetBrand(int id);
        SearchResult<Brand> AddBrand(Brand model);
        SearchResult<int> DeleteBrand(int id);
        SearchResult<Brand> EditBrand(int id, Brand model);
    }
}
