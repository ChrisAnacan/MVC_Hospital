using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_MVC.Utils
{
    public class SelectList : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
