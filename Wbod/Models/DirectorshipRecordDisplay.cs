using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Wbod.Models.DB;

namespace Wbod.Models
{
    public class DirectorshipRecordDisplay : ViewComponent
    {
        private readonly WbodContext _context;

        public DirectorshipRecordDisplay (WbodContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int Id)
        {
            string DrId = RouteData.Values["id"] as string;
            int DId = Int32.Parse(DrId);
            var result = _context.Directorship.AsNoTracking().Where(p => p.Directorid == DId)
                .Select(p => new DirectorshipRecordVM
                {
                    Id = p.Id,
                    Sessionyear = p.Session.Sessionyear,
                    Companyname = p.Company.Companyname
                });

            return View(result);

        }
    }
}
