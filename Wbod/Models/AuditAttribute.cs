using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wbod.Models.DB;
using Microsoft.AspNetCore.Http.Extensions;

namespace Wbod.Models
{
    public class AuditAttribute : ActionFilterAttribute
    {
        private readonly WbodContext _context;
        public AuditAttribute(WbodContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;

            //Generate an audit
            Audit audit = new Audit()
            {
                AuditId = Guid.NewGuid(),
                Ipaddress = request.HttpContext.Connection.RemoteIpAddress.ToString(),
                AreaAccessed = request.GetDisplayUrl(),
                Timestamp = DateTime.UtcNow,
                UserName = filterContext.HttpContext.User.Identity.Name 
            };

            //Add to DB
            //WbodContext context = new WbodContext();
            _context.Audit.Add(audit);
            _context.SaveChanges();

            base.OnActionExecuting(filterContext);
        }
    }
}
