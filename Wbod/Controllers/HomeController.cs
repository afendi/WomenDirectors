using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wbod.Models;
using Microsoft.AspNetCore.Authorization;
using Wbod.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Wbod.Controllers
{
    public class HomeController : Controller
    {
        private readonly WbodContext _context;

        public HomeController(WbodContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Companies
        public ActionResult Index()
        {
            List<SimpleCompany> CompanySimplifiedlist = new List<SimpleCompany>();
            var datalist = _context.Companies
                           .Select(co => new { co.Id, co.Companyname }).ToList();
            foreach (var item in datalist)
            {
                SimpleCompany sc = new SimpleCompany();
                sc.Id = item.Id;
                sc.CompanyName = item.Companyname;
                CompanySimplifiedlist.Add(sc);
            }
            return View(CompanySimplifiedlist);

            //return View(await _context.Companies.Select(s => new { s.Id, s.Companyname }).ToListAsync());
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
