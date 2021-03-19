using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        Product GetProductDetails(string url);
        Product GetByIdWithCategories(int id);

        Product GetById(int id);

        List<Product> GetAll();
        List<Product> GetSearchResult(string searchString);

        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        List<Product> GetHomePageProducts();
        void Create(Product entity);

        void Update(Product entity);

        void Delete(Product entity);
        int GetCountByCategory(string category);
        void Update(Product entity, int[] categoryIds);
    }
}
