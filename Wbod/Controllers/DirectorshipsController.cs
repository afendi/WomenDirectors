using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wbod.Models.DB;
using Wbod.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Wbod.Controllers
{
    public class DirectorshipsController : Controller
    {
        private readonly WbodContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public DirectorshipsController(WbodContext context, IHostingEnvironment environment)
        {
            _context = context;
            hostingEnvironment = environment;
        }

        

        // GET: Directorships
        public async Task<IActionResult> Index()
        {
            var wbodContext = _context.Directorship.Include(d => d.Company).Include(d => d.Director).Include(d => d.Session);
            return View(await wbodContext.ToListAsync());
        }

        // GET: Directorships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directorship = await _context.Directorship
                .Include(d => d.Company)
                .Include(d => d.Director)
                .Include(d => d.Session)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (directorship == null)
            {
                return NotFound();
            }

            return View(directorship);
        }

        // GET: Directorships/Create
        public IActionResult Create()
        {
            ViewData["Companyid"] = new SelectList(_context.Companies, "Id", "Companyname");
            ViewData["Directorid"] = new SelectList(_context.Directors, "Id", "Name");
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Sessionyear");
            return View();
        }

        // POST: Directorships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cdp1,Cdp2,Daudit,Drenum,Dnom,Desos,Drisk,Dexec,Dtender,Dfinance,Duration,Directorid,Companyid,SessionId")] Directorship directorship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directorship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Companyid"] = new SelectList(_context.Companies, "Id", "Companyname", directorship.Companyid);
            ViewData["Directorid"] = new SelectList(_context.Directors, "Id", "Name", directorship.Directorid);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Sessionyear", directorship.SessionId);
            return View(directorship);
        }

        // GET: Directorships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directorship = await _context.Directorship.SingleOrDefaultAsync(m => m.Id == id);
            if (directorship == null)
            {
                return NotFound();
            }
            //ViewData["Companyid"] = new SelectList(_context.Companies, "Id", "Companyname", directorship.Companyid);
            //ViewData["Directorid"] = new SelectList(_context.Directors, "Id", "Name", directorship.Directorid);
            //ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Sessionyear", directorship.SessionId);

            // Grab the previous URL and add it to the Model Wbod ViewData or ViewBag
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            ViewData["Currentdirpositionone"] = new SelectList(_context.Currentdirpositionone, "Id", "Positiontype");
            ViewData["Currentdirpositiontwo"] = new SelectList(_context.Currentdirpositiontwo, "Id", "Positiontype");
            ViewData["Directoraudit"] = new SelectList(_context.Directoraudit, "Id", "Positiontype");
            ViewData["Directorrenum"] = new SelectList(_context.Directorrenum, "Id", "Positiontype");
            ViewData["Directornom"] = new SelectList(_context.Directornom, "Id", "Positiontype");
            ViewData["Directoresos"] = new SelectList(_context.Directoresos, "Id", "Positiontype");
            ViewData["Directorrisk"] = new SelectList(_context.Directorrisk, "Id", "Positiontype");
            ViewData["Directorexec"] = new SelectList(_context.Directorexec, "Id", "Positiontype");
            ViewData["Directortender"] = new SelectList(_context.Directortender, "Id", "Positiontype");
            ViewData["Directorfinance"] = new SelectList(_context.Directorfinance, "Id", "Positiontype");

            return View(directorship);
        }

        // POST: Directorships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string returnUrl, [Bind("Id,Cdp1,Cdp2,Daudit,Drenum,Dnom,Desos,Drisk,Dexec,Dtender,Duration,Directorid,Companyid,SessionId")] Directorship directorship)
        {
            if (id != directorship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directorship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorshipExists(directorship.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return Redirect(returnUrl);
            }
            //ViewData["Companyid"] = new SelectList(_context.Companies, "Id", "Companyname", directorship.Companyid);
            //ViewData["Directorid"] = new SelectList(_context.Directors, "Id", "Name", directorship.Directorid);
            //ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Sessionyear", directorship.SessionId);
            return View(directorship);
        }

        // GET: Directorships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directorship = await _context.Directorship
                .Include(d => d.Company)
                .Include(d => d.Director)
                .Include(d => d.Session)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (directorship == null)
            {
                return NotFound();
            }
            ViewBag.Comapnyid = directorship.Companyid;
            return View(directorship);
        }

        // POST: Directorships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int Companyid)
        {
            var directorship = await _context.Directorship.SingleOrDefaultAsync(m => m.Id == id);
            _context.Directorship.Remove(directorship);
            await _context.SaveChangesAsync();
            return Redirect("/Directorships/GetCompanyDirectors/" + Companyid);
        }

        private bool DirectorshipExists(int id)
        {
            return _context.Directorship.Any(e => e.Id == id);
        }

        public ActionResult GetCompanyDirectors(int id)
        {
            List<SimpleDirectorship> ListDirectorsByCompany = new List<SimpleDirectorship>();
            var latestsession = _context.Sessions.Max(x => x.Id);
            var cdirectors = from d in _context.Directorship.Include(d => d.Cdp1Navigation).Include(d => d.Cdp2Navigation).Include(d => d.DauditNavigation).Include(d => d.DnomNavigation).Include(d => d.DrenumNavigation)
                             join c in _context.Companies
                             on d.Companyid equals c.Id
                             join dr in _context.Directors
                             on d.Directorid equals dr.Id
                             join ss in _context.Sessions
                             on d.SessionId equals ss.Id
                             where d.Companyid == id && ss.Id == latestsession
                             select new { d.Id, CDP1=d.Cdp1Navigation.Positiontype, CDP2=d.Cdp2Navigation.Positiontype, DirectorAudit=d.DauditNavigation.Positiontype, DirectorRenumeration=d.DrenumNavigation.Positiontype, DirectorNomination=d.DnomNavigation.Positiontype, d.Duration, d.Directorid, d.Companyid, d.SessionId, Company=c.Companyname, DirectorName=dr.Name, Year=ss.Sessionyear };

            foreach (var item in cdirectors)
            {
                SimpleDirectorship sd = new SimpleDirectorship
                {
                    Id = item.Id,
                    CDP1 = item.CDP1,
                    CDP2 = item.CDP2,
                    DirectorAudit = item.DirectorAudit,
                    DirectorRenumeration = item.DirectorRenumeration,
                    DirectorNomination = item.DirectorNomination,
                    Duration = item.Duration,
                    Directorid = item.Directorid,
                    Companyid = item.Companyid,
                    SessionId = item.SessionId,
                    Company = item.Company,
                    DirectorName = item.DirectorName,
                    Year = item.Year
                };
                ListDirectorsByCompany.Add(sd);
            }

            return View(ListDirectorsByCompany);
                
            //return Json(cdirectors);
                

        }
        [Route("Directorships/Records/Company/{Companyid:int}/Session/{Sessionid:int}")]
        public ActionResult GetRecords (int CompanyId, int SessionId)
        {
            List<SimpleDirectorship> ListRecordByCompany = new List<SimpleDirectorship>();
            var rdirector = from d in _context.Directorship
                            join c in _context.Companies
                            on d.Companyid equals c.Id
                            join dr in _context.Directors
                            on d.Directorid equals dr.Id
                            where d.Companyid == CompanyId && d.SessionId == SessionId
                            select new { d.Id, CDP1 = d.Cdp1Navigation.Positiontype, CDP2 = d.Cdp2Navigation.Positiontype, DirectorAudit = d.DauditNavigation.Positiontype, DirectorRenumeration = d.DrenumNavigation.Positiontype, DirectorNomination = d.DnomNavigation.Positiontype, d.Duration, d.Director.Name, d.Session.Sessionyear, d.Company.Companyname };

            foreach (var item in rdirector)
            {
                SimpleDirectorship sd = new SimpleDirectorship
                {
                    Id = item.Id,
                    CDP1 = item.CDP1,
                    CDP2 = item.CDP2,
                    DirectorAudit = item.DirectorAudit,
                    DirectorRenumeration = item.DirectorRenumeration,
                    DirectorNomination = item.DirectorNomination,
                    Duration = item.Duration,
                    DirectorName = item.Name,
                    Company = item.Companyname,
                    Year = item.Sessionyear
                };
                ListRecordByCompany.Add(sd);

            }
            return View(ListRecordByCompany);
        }

        [Route("Directorships/Company/{Companyid:int}/Session/{Sessionid:int}")]
        public ActionResult GetDirectorList(int Companyid, int Sessionid)
        {
            ViewBag.SessionId = Sessionid;
            ViewBag.CompanyId = Companyid;
            //ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            ViewData["Currentdirpositionone"] = new SelectList(_context.Currentdirpositionone, "Id", "Positiontype");
            ViewData["Currentdirpositiontwo"] = new SelectList(_context.Currentdirpositiontwo, "Id", "Positiontype");
            ViewData["Directoraudit"] = new SelectList(_context.Directoraudit, "Id", "Positiontype");
            ViewData["Directorrenum"] = new SelectList(_context.Directorrenum, "Id", "Positiontype");
            ViewData["Directornom"] = new SelectList(_context.Directornom, "Id", "Positiontype");
            ViewData["Directoresos"] = new SelectList(_context.Directoresos, "Id", "Positiontype");
            ViewData["Directorrisk"] = new SelectList(_context.Directorrisk, "Id", "Positiontype");
            ViewData["Directorexec"] = new SelectList(_context.Directorexec, "Id", "Positiontype");
            ViewData["Directortender"] = new SelectList(_context.Directortender, "Id", "Positiontype");
            ViewData["Directorfinance"] = new SelectList(_context.Directorfinance, "Id", "Positiontype");
            return View();
        }
        [Route("Directorships/Company/{Companyid:int}/Session/{Sessionid:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AttachDirector([Bind("Id,Cdp1,Cdp2,Daudit,Drenum,Dnom,Drisk,Dexec,Dtender,DfinanceDuration,Directorid,Companyid,SessionId")] Directorship directorship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directorship);
                await _context.SaveChangesAsync();
                return Redirect("/Directorships/GetCompanyDirectors/"+directorship.Companyid);
            }
            return Redirect("/Directorships/Company/"+directorship.Companyid+"/Session/"+directorship.SessionId);
        }
        [Route("Directorships/AttachDirector/{Companyid:int}/Session/{Sessionid:int}")]
        public ActionResult AddNewDirectorAndAttach (int Companyid, int Sessionid)
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
            ViewData["Fieldofstudies2"] = new SelectList(_context.Fieldofstudiestable2, "Id", "Fieldname");
            ViewData["Gender"] = new SelectList(_context.Gendertable, "Id", "Gendertype");
            ViewData["Placeofeducation"] = new SelectList(_context.Placeofeducationtable, "Id", "Place");
            ViewData["Professionalbody"] = new SelectList(_context.Professionalbodytable, "Id", "Organizationtype");
            ViewData["Titledarjah"] = new SelectList(_context.Titletable, "Id", "Titletype");
            ViewData["Voluntarybody"] = new SelectList(_context.Voluntarybodytable, "Id", "Organizationtype");
            ViewBag.SessionId = Sessionid;
            ViewBag.CompanyId = Companyid;
            return View();
        }

        [HttpPost]
        [Route("Directorships/AttachDirector/{Companyid:int}/Session/{Sessionid:int}")]
        public async Task<IActionResult> AddNewDirectorAndAttach (int CompanyId, int SessionId, [Bind("Id,Name,Gender,Info,Photo,Age,Citizenship,Ethnicity,Educationlevel,Placeofeducation,Fieldofstudies,Fieldofstudies2,Titledarjah,Familytiesone,Familytiestwo,Professionalbody,Voluntarybody,Cweplc,Cwenonplc,Cwegovt,Cweacademic,Yearofbirth,MyImage")] Directors directors)
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

                return Redirect("/Directorships/AddDirector/Company/"+CompanyId+"/Session/"+SessionId+"/Director/"+directors.Id);

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

        [Route("Directorships/AddDirector/Company/{Companyid}/Session/{Sessionid}/Director/{Directorid}")]
        public ActionResult AddDirectorToPosition (int CompanyId, int SessionId, int DirectorId)
        {
            ViewBag.CompanyId = CompanyId;
            ViewBag.SessionId = SessionId;
            ViewBag.DirectorId = DirectorId;
            ViewData["Currentdirpositionone"] = new SelectList(_context.Currentdirpositionone, "Id", "Positiontype");
            ViewData["Currentdirpositiontwo"] = new SelectList(_context.Currentdirpositiontwo, "Id", "Positiontype");
            ViewData["Directoraudit"] = new SelectList(_context.Directoraudit, "Id", "Positiontype");
            ViewData["Directorrenum"] = new SelectList(_context.Directorrenum, "Id", "Positiontype");
            ViewData["Directornom"] = new SelectList(_context.Directornom, "Id", "Positiontype");
            ViewData["Directoresos"] = new SelectList(_context.Directoresos, "Id", "Positiontype");
            ViewData["Directorrisk"] = new SelectList(_context.Directorrisk, "Id", "Positiontype");
            ViewData["Directorexec"] = new SelectList(_context.Directorexec, "Id", "Positiontype");
            ViewData["Directortender"] = new SelectList(_context.Directortender, "Id", "Positiontype");
            ViewData["Directorfinance"] = new SelectList(_context.Directorfinance, "Id", "Positiontype");
            string namad = (from d in _context.Directors where d.Id == DirectorId select d.Name ).First().ToString();
            ViewBag.Directorname = namad;
            return View();
        }

        [HttpPost]
        [Route("Directorships/AddDirector/Company/{Companyid}/Session/{Sessionid}/Director/{Directorid}")]
        public async Task<IActionResult> AddDirectorToPosition(int CompanyId, int SessionId, int DirectorId, [Bind("Id,Cdp1,Cdp2,Daudit,Drenum,Dnom,Duration,Directorid,Companyid,SessionId")] Directorship directorship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directorship);
                await _context.SaveChangesAsync();
                return Redirect("/Directorships/GetCompanyDirectors/" + directorship.Companyid);
            }
            return View();
        }
    }
}
