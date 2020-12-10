using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
//        public static void Seed()
//        {
//            var context = new ShopContext();

//            if (context.Database.GetPendingMigrations().Count() == 0)
//            {
//                if (context.Categories.Count() == 0)
//                {
//                    context.Categories.AddRange(Categories);
//                }
//                if (context.Products.Count() == 0)
//                {
//                    context.Products.AddRange(Products);
//                    context.AddRange(ProductCategories); 
//                }
//            }
//            context.SaveChanges();
//        }

//        private static Category[] Categories =
//        {
//            new Category(){Name="Telefon",Url="telefon"},
//            new Category(){Name="Bilgisayar",Url="bilgisayar"},
//            new Category(){Name="Elektronik",Url="elektronik"},
//            new Category(){Name="Beyaz Eşya",Url="beyaz-esya"}
//        };
//        private static Product[] Products =
//       {
//new Product(){Name="Samsung S5",Url="samsung-s5", Price=2999,ImageUrl="1.jpg",Description="iyi telefon",isApproved=true,isHome=true},
//new Product(){Name="Samsung S6",Url="samsung-s6",Price=3999,ImageUrl="2.jpg",Description="çok iyi telefon",isApproved=false,isHome=false},
//new Product(){Name="Samsung S7",Url="samsung-s7",Price=4999,ImageUrl="3.jpg",Description="yeni nesil telefon",isApproved=true,isHome=true},
//new Product(){Name="Lenova",Url="lenova",Price=5999,ImageUrl="4.jpg",Description="iyinin ötesinde",isApproved=false,isHome=false},
//new Product(){Name="Asus",Url="asus",Price=6999,ImageUrl="1.jpg",Description="daha akıllısı yok",isApproved=true,isHome=true}

//        };

//        private static ProductCategory[] ProductCategories = {
//            new ProductCategory(){Product=Products[0],Category=Categories[0]},                              
//            new ProductCategory(){Product=Products[0],Category=Categories[2]},                              
//            new ProductCategory(){Product=Products[1],Category=Categories[0]},                              
//            new ProductCategory(){Product=Products[1],Category=Categories[2]},                              
//            new ProductCategory(){Product=Products[2],Category=Categories[0]},                              
//            new ProductCategory(){Product=Products[2],Category=Categories[2]},                              
//            new ProductCategory(){Product=Products[3],Category=Categories[1]},                              
//            new ProductCategory(){Product=Products[3],Category=Categories[2]},
//            new ProductCategory(){Product=Products[4],Category=Categories[1]},
//            new ProductCategory(){Product=Products[4],Category=Categories[2]}
//        };
    }
}
