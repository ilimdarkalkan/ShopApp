﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }

        public IActionResult Index()
        {
            var productViewModel = new ProductListViewModel()
            {
               
                Products = _productService.GetHomePageProducts()
            };
            return View(productViewModel);
        }
      public IActionResult About()
        {
            return View();
        }
    }
}