using Accounting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            var inv = new Invoice()
            {
                CompanyName = "Neon Clouds",
                CompanyLocation = new Location()
                {
                    Street = "Kibera Station Road",
                    Town = "Jamhuri Estate",
                    Area = "Nairobi",
                    Country = "Kenya",
                    Tel = "+254716177297"
                }
            };
            return View(inv);
        }
    }
}
