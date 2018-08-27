using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wbod.Models.DB;
using Wbod.Models;
using System.IO;

namespace Wbod.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly WbodContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public DirectorsController(WbodContext context, IHostingEnvironment environment)
        {
            _context = context;
            hostingEnvironment = environment;
        }

        // GET: Directors
        public IActionResult Index()
        {
            //var wbodContext = _context.Directors.Include(d => d.CitizenshipNavigation).Include(d => d.CweacademicNavigation).Include(d => d.CwegovtNavigation).Include(d => d.CwenonplcNavigation).Include(d => d.CweplcNavigation).Include(d => d.EducationlevelNavigation).Include(d => d.EthnicityNavigation).Include(d => d.FamilytiesoneNavigation).Include(d => d.FamilytiestwoNavigation).Include(d => d.FieldofstudiesNavigation).Include(d => d.GenderNavigation).Include(d => d.PlaceofeducationNavigation).Include(d => d.ProfessionalbodyNavigation).Include(d => d.TitledarjahNavigation).Include(d => d.VoluntarybodyNavigation);
            // --changed -- var wbodContext = _context.Directors;
            // return View(await wbodContext.ToListAsync());
            return RedirectToActionPermanent("List");
        }

        public IActionResult List()
        {
            return View();
        }

        //try json
        public IActionResult DirectorJson()
        {
            var wbodDirectors = _context.Directors.AsNoTracking()
                .Select(p => new SimpleDirector()
                {
                    Id = p.Id,
                    Name = p.Name
                });
            return Json(wbodDirectors);
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors
                .Include(d => d.CitizenshipNavigation)
                .Include(d => d.CweacademicNavigation)
                .Include(d => d.CwegovtNavigation)
                .Include(d => d.CwenonplcNavigation)
                .Include(d => d.CweplcNavigation)
                .Include(d => d.EducationlevelNavigation)
                .Include(d => d.EthnicityNavigation)
                .Include(d => d.FamilytiesoneNavigation)
                .Include(d => d.FamilytiestwoNavigation)
                .Include(d => d.FieldofstudiesNavigation)
                .Include(d => d.FieldofstudiesNavigation2)
                .Include(d => d.GenderNavigation)
                .Include(d => d.PlaceofeducationNavigation)
                .Include(d => d.ProfessionalbodyNavigation)
                .Include(d => d.TitledarjahNavigation)
                .Include(d => d.VoluntarybodyNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (directors == null)
            {
                return NotFound();
            }

            return View(directors);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            ViewData["Citizenship"] = new SelectList(_context.Citizenshiptable, "Id", "Citizentype");
            ViewData["Cweacademic"] = new SelectList(_context.Cweacadtable, "Id", "Positiontype");
            ViewData["Cwegovt"] = new SelectList(_context.Cwegovtable, "Id", "Positiontype");
            ViewData["Cwenonplc"] = new SelectList(_context.Cwenonplctable, "Id", "Positiontype");
            ViewData["Cweplc"] = new SelectList(_context.Cweplctable, "Id", "Positiontype");
            ViewData["Educationlevel"] = new SelectList(_context.Educationlevel, "Id", "Edulevel");
            ViewData["Ethnicity"] = new SelectList(_context.Ethnicitytable, "Id", "Race");
            ViewData["Familytiesone"] = new SelectList(_context.Familytiesonetable, "Id", "Id");
            ViewData["Familytiestwo"] = new SelectList(_context.Familytiestwotable, "Id", "Id");
            ViewData["Fieldofstudies"] = new SelectList(_context.Fieldofstudiestable, "Id", "Fieldname");
            ViewData["Fieldofstudies2"] = new SelectList(_context.Fieldofstudiestable, "Id", "Fieldname");
            ViewData["Gender"] = new SelectList(_context.Gendertable, "Id", "Gendertype");
            ViewData["Placeofeducation"] = new SelectList(_context.Placeofeducationtable, "Id", "Place");
            ViewData["Professionalbody"] = new SelectList(_context.Professionalbodytable, "Id", "Id");
            ViewData["Titledarjah"] = new SelectList(_context.Titletable, "Id", "Id");
            ViewData["Voluntarybody"] = new SelectList(_context.Voluntarybodytable, "Id", "Id");
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Info,Photo,Age,Citizenship,Ethnicity,Educationlevel,Placeofeducation,Fieldofstudies,Fieldofstudies2,Titledarjah,Familytiesone,Familytiestwo,Professionalbody,Voluntarybody,Cweplc,Cwenonplc,Cwegovt,Cweacademic,Yearofbirth")] Directors directors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Citizenship"] = new SelectList(_context.Citizenshiptable, "Id", "Citizentype", directors.Citizenship);
            ViewData["Cweacademic"] = new SelectList(_context.Cweacadtable, "Id", "Positiontype", directors.Cweacademic);
            ViewData["Cwegovt"] = new SelectList(_context.Cwegovtable, "Id", "Positiontype", directors.Cwegovt);
            ViewData["Cwenonplc"] = new SelectList(_context.Cwenonplctable, "Id", "Positiontype", directors.Cwenonplc);
            ViewData["Cweplc"] = new SelectList(_context.Cweplctable, "Id", "Positiontype", directors.Cweplc);
            ViewData["Educationlevel"] = new SelectList(_context.Educationlevel, "Id", "Edulevel", directors.Educationlevel);
            ViewData["Ethnicity"] = new SelectList(_context.Ethnicitytable, "Id", "Race", directors.Ethnicity);
            ViewData["Familytiesone"] = new SelectList(_context.Familytiesonetable, "Id", "Id", directors.Familytiesone);
            ViewData["Familytiestwo"] = new SelectList(_context.Familytiestwotable, "Id", "Id", directors.Familytiestwo);
            ViewData["Fieldofstudies"] = new SelectList(_context.Fieldofstudiestable, "Id", "Fieldname", directors.Fieldofstudies);
            ViewData["Fieldofstudies2"] = new SelectList(_context.Fieldofstudiestable, "Id", "Fieldname", directors.Fieldofstudies2);
            ViewData["Gender"] = new SelectList(_context.Gendertable, "Id", "Gendertype", directors.Gender);
            ViewData["Placeofeducation"] = new SelectList(_context.Placeofeducationtable, "Id", "Place", directors.Placeofeducation);
            ViewData["Professionalbody"] = new SelectList(_context.Professionalbodytable, "Id", "Id", directors.Professionalbody);
            ViewData["Titledarjah"] = new SelectList(_context.Titletable, "Id", "Id", directors.Titledarjah);
            ViewData["Voluntarybody"] = new SelectList(_context.Voluntarybodytable, "Id", "Id", directors.Voluntarybody);
            return View(directors);
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors.SingleOrDefaultAsync(m => m.Id == id);
            if (directors == null)
            {
                return NotFound();
            }
            ViewData["Citizenship"] = new SelectList(_context.Citizenshiptable, "Id", "Citizentype", directors.Citizenship);
            ViewData["Cweacademic"] = new SelectList(_context.Cweacadtable, "Id", "Positiontype", directors.Cweacademic);
            ViewData["Cwegovt"] = new SelectList(_context.Cwegovtable, "Id", "Positiontype", directors.Cwegovt);
            ViewData["Cwenonplc"] = new SelectList(_context.Cwenonplctable, "Id", "Positiontype", directors.Cwenonplc);
            ViewData["Cweplc"] = new SelectList(_context.Cweplctable, "Id", "Positiontype", directors.Cweplc);
            ViewData["Educationlevel"] = new SelectList(_context.Educationlevel, "Id", "Edulevel", directors.Educationlevel);
            ViewData["Ethnicity"] = new SelectList(_context.Ethnicitytable, "Id", "Race", directors.Ethnicity);
            ViewData["Familytiesone"] = new SelectList(_context.Familytiesonetable, "Id", "Tiestype", directors.Familytiesone);
            ViewData["Familytiestwo"] = new SelectList(_context.Familytiestwotable, "Id", "Tiestype", directors.Familytiestwo);
            ViewData["Fieldofstudies"] = new SelectList(_context.Fieldofstudiestable, "Id", "Fieldname", directors.Fieldofstudies);
            ViewData["Fieldofstudies2"] = new SelectList(_context.Fieldofstudiestable, "Id", "Fieldname", directors.Fieldofstudies2);
            ViewData["Gender"] = new SelectList(_context.Gendertable, "Id", "Gendertype", directors.Gender);
            ViewData["Placeofeducation"] = new SelectList(_context.Placeofeducationtable, "Id", "Place", directors.Placeofeducation);
            ViewData["Professionalbody"] = new SelectList(_context.Professionalbodytable, "Id", "Organizationtype", directors.Professionalbody);
            ViewData["Titledarjah"] = new SelectList(_context.Titletable, "Id", "Titletype", directors.Titledarjah);
            ViewData["Voluntarybody"] = new SelectList(_context.Voluntarybodytable, "Id", "Organizationtype", directors.Voluntarybody);
            return View(directors);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Info,Photo,Age,Citizenship,Ethnicity,Educationlevel,Placeofeducation,Fieldofstudies,Fieldofstudies2,Titledarjah,Familytiesone,Familytiestwo,Professionalbody,Voluntarybody,Cweplc,Cwenonplc,Cwegovt,Cweacademic,Yearofbirth,MyImage")] Directors directors)
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

                _context.Update(directors);
                await _context.SaveChangesAsync();

                return Redirect("/Directors/Details/" + directors.Id);

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

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors
                .Include(d => d.CitizenshipNavigation)
                .Include(d => d.CweacademicNavigation)
                .Include(d => d.CwegovtNavigation)
                .Include(d => d.CwenonplcNavigation)
                .Include(d => d.CweplcNavigation)
                .Include(d => d.EducationlevelNavigation)
                .Include(d => d.EthnicityNavigation)
                .Include(d => d.FamilytiesoneNavigation)
                .Include(d => d.FamilytiestwoNavigation)
                .Include(d => d.FieldofstudiesNavigation)
                .Include(d => d.GenderNavigation)
                .Include(d => d.PlaceofeducationNavigation)
                .Include(d => d.ProfessionalbodyNavigation)
                .Include(d => d.TitledarjahNavigation)
                .Include(d => d.VoluntarybodyNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (directors == null)
            {
                return NotFound();
            }

            return View(directors);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directors = await _context.Directors.SingleOrDefaultAsync(m => m.Id == id);
            _context.Directors.Remove(directors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorsExists(int id)
        {
            return _context.Directors.Any(e => e.Id == id);
        }
    }
}
