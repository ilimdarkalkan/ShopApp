using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string url);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        List<Product> GetPopularProducts();
        List<Product> GetTop5Products();
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);

        Product GetByIdWithCategories(int id);
        int GetCountByCategory(string category);
        void Update(Product entity, int[] categoryIds);
    }
}
