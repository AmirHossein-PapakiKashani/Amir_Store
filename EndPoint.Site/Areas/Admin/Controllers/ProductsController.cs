﻿using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
