using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Wbod.Models.DB;

namespace Wbod.Models
{
    public class CompanyListDirectorship : ViewComponent
    {
        private readonly WbodContext _context;

        public CompanyListDirectorship ( WbodContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            List<SessionRecordsVM> ListSR = new List<SessionRecordsVM>();
            string coId = RouteData.Values["id"] as string;
            int cid = Int32.Parse(coId);
            var drecords = _context.Sessions.OrderByDescending(s => s.Id).Skip(1);

            foreach (var item in drecords)
            {
                SessionRecordsVM sr = new SessionRecordsVM
                {
                    Id = item.Id,
                    sessionyear = item.Sessionyear,
                    cId = cid

                };
                ListSR.Add(sr);
            }

            return View(ListSR);
                           
        }
    }
}
