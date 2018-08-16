using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wbod.Models;
using Wbod.Models.DB;


namespace Wbod.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly WbodContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public CompaniesController(WbodContext context, IHostingEnvironment environment)
        {
            _context = context;
            hostingEnvironment = environment;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companies = await _context.Companies
                .Include(c => c.IsglcNavigation)
                .Include(c => c.CompanytypeNavigation)
                .Include(c => c.CompanysectorNavigation)
                .Include(c => c.CompanylistNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (companies == null)
            {
                return NotFound();
            }

            return View(companies);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["Isglc"] = new SelectList(_context.Glcstatus, "Id", "Isglcstatus");
            ViewData["Companysector"] = new SelectList(_context.Companysectors, "Id", "Sectornames");
            ViewData["Companytype"] = new SelectList(_context.Companytypes, "Id", "Typenames");
            ViewData["Companylist"] = new SelectList(_context.Companylists, "Id", "Companylistsname");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Companyname,Isglc,Companysector,Companytype,Companylist,Companyboardsize,Companyisactive")] Companies companies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companies);
                await _context.SaveChangesAsync();
                ViewBag.CompanyId = companies.Id;
                var latestsession = _context.Sessions.Max(x => x.Id);
                ViewBag.SessionId = latestsession;
                return Redirect("/Directorships/Company/" + companies.Id+"/Session/"+latestsession);
            }
            return View(companies);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companies = await _context.Companies.SingleOrDefaultAsync(m => m.Id == id);
            if (companies == null)
            {
                return NotFound();
            }
            ViewData["Isglc"] = new SelectList(_context.Glcstatus, "Id", "Isglcstatus", companies.Isglc);
            ViewData["Companysector"] = new SelectList(_context.Companysectors, "Id", "Sectornames", companies.Companysector);
            ViewData["Companytype"] = new SelectList(_context.Companytypes, "Id", "Typenames", companies.Companytype);
            ViewData["Companylist"] = new SelectList(_context.Companylists, "Id", "Companylistsname", companies.Companylist);
            return View(companies);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Audit]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Companyname,Isglc,Companysector,Companytype,Companylist,Companyboardsize,Companyisactive")] Companies companies)
        {
            if (id != companies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompaniesExists(companies.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details","Companies", new { @id = id });
            }
            ViewData["Isglc"] = new SelectList(_context.Glcstatus, "Id", "Isglcstatus", companies.Isglc);
            ViewData["Companysector"] = new SelectList(_context.Companysectors, "Id", "Sectornames", companies.Companysector);
            ViewData["Companytype"] = new SelectList(_context.Companytypes, "Id", "Typenames", companies.Companytype);
            ViewData["Companylist"] = new SelectList(_context.Companylists, "Id", "Companylistsname", companies.Companylist);
            return View(companies);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companies = await _context.Companies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (companies == null)
            {
                return NotFound();
            }

            return View(companies);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companies = await _context.Companies.SingleOrDefaultAsync(m => m.Id == id);
            _context.Companies.Remove(companies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Directorj()
        {
            var womendirectorContext = _context.Directors.Select(i => new { i.Id, i.Name });
            return Json(womendirectorContext.ToArray());
        }

        private bool CompaniesExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
        [Route("Companies/AddDirectorToNewCompany/Company/{CompanyId}/Session/{SessionId}")]
        public ActionResult AddDirectorToNewCompany (int CompanyId, int SessionId)
        {
            ViewData["Citizenship"] = new SelectList(_context.Citizenshiptable, "Id", "Citizentype");
            ViewData["Cweacademic"] = new SelectList(_context.Cweacadtable, "Id", "Positiontype");
            ViewData["Cwegovt"] = new SelectList(_context.Cwegovtable, "Id", "Positiontype");
            ViewData["Cwenonplc"] = new SelectList(_context.Cwenonplctable, "Id", "Positiontype");
            ViewData["Cweplc"] = new SelectList(_context.Cweplctable, "Id", "Positiontype");
            ViewData["Educationlevel"] = new SelectList(_context.Educationlevel, "Id", "Edulevel");
            ViewData["Ethnicity"] = new SelectList(_context.Ethnicitytable, "Id", "Race");
            ViewData["Familytiesone"] = new SelectList(_context.Familytiesonetable, "Id", "Tiestype");
            ViewData["Familytiestwo"] = new SelectList(_context.Familytiestwotable, "Id", "Tiestype");
            ViewData["Fieldofstudies"] = new SelectList(_context.Fieldofstudiestable, "Id", "Fieldname");
            ViewData["Gender"] = new SelectList(_context.Gendertable, "Id", "Gendertype");
            ViewData["Placeofeducation"] = new SelectList(_context.Placeofeducationtable, "Id", "Place");
            ViewData["Professionalbody"] = new SelectList(_context.Professionalbodytable, "Id", "Organizationtype");
            ViewData["Titledarjah"] = new SelectList(_context.Titletable, "Id", "Titletype");
            ViewData["Voluntarybody"] = new SelectList(_context.Voluntarybodytable, "Id", "Organizationtype");
            ViewBag.SessionId = SessionId;
            ViewBag.CompanyId = CompanyId;
            return View();
        }

        [HttpPost]
        [Route("Companies/AddDirectorToNewCompany/Company/{CompanyId}/Session/{SessionId}")]
        public async Task<IActionResult> AddDirectorToNewCompany(int CompanyId, int SessionId, [Bind("Id,Name,Gender,Info,Photo,Age,Citizenship,Ethnicity,Educationlevel,Placeofeducation,Fieldofstudies,Titledarjah,Familytiesone,Familytiestwo,Professionalbody,Voluntarybody,Cweplc,Cwenonplc,Cwegovt,Cweacademic,Yearofbirth,MyImage")] Directors directors)
        {
            if (ModelState.IsValid)
            {
                //string img = directors.MyImage.FileName;
                if (directors.MyImage != null)
                {
                    var uniqueFileName = GetUniqueName(directors.MyImage.FileName);
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "photos");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    directors.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));
                    directors.Photo = uniqueFileName;
                }

                _context.Add(directors);
                await _context.SaveChangesAsync();
                ViewBag.CompanyId = CompanyId;
                ViewBag.SessionId = SessionId;

                return Redirect("/Companies/AttachDirectorToNewCompany/Company/"+CompanyId+"/Director/"+directors.Id+"/Session/"+SessionId);

            }

            return View();

        }

        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        [Route("Companies/AttachDirectorToNewCompany/Company/{CompanyId}/Director/{DirectorId}/Session/{SessionId}")]
        public ActionResult AttachDirectorToNewCompany (int CompanyId, int DirectorId, int SessionId)
        {
            ViewBag.SessionId = SessionId;
            ViewBag.CompanyId = CompanyId;
            ViewBag.DirectorId = DirectorId;
            //ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            ViewBag.DirectorName = _context.Directors.Single(d => d.Id == DirectorId).Name;
            ViewBag.CompanyName = _context.Companies.Single(c => c.Id == CompanyId).Companyname;
            ViewData["Currentdirpositionone"] = new SelectList(_context.Currentdirpositionone, "Id", "Positiontype");
            ViewData["Currentdirpositiontwo"] = new SelectList(_context.Currentdirpositiontwo, "Id", "Positiontype");
            ViewData["Directoraudit"] = new SelectList(_context.Directoraudit, "Id", "Positiontype");
            ViewData["Directorrenum"] = new SelectList(_context.Directorrenum, "Id", "Positiontype");
            ViewData["Directornom"] = new SelectList(_context.Directornom, "Id", "Positiontype");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Companies/AttachDirectorToNewCompany/Company/{CompanyId}/Director/{DirectorId}/Session/{SessionId}")]
        public async Task<IActionResult> AttachDirectorToNewCompany([Bind("Id,Cdp1,Cdp2,Daudit,Drenum,Dnom,Duration,Directorid,Companyid,SessionId")] Directorship directorship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directorship);
                await _context.SaveChangesAsync();
                return Redirect("/Directorships/GetCompanyDirectors/" + directorship.Companyid);
            }
            return View(directorship);
        }
    }

    
}
