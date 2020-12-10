﻿using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int categoryId, int productId);

    }
}
