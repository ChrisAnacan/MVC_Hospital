using Hospital_MVC.Data;
using Hospital_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_MVC.Controllers
{
    // TO DO - fix your "create + back" button on Hiring page, Create + Link your "Review Hire" page. Make sure everything works.

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Doctors()
        {
            var docs = await _context.DoctorsTable.ToListAsync();
            return View(docs);
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        //HttpPost-SearchForm()
        [HttpPost]
        public IActionResult SearchForm(string Doctor_Name)
        {
            var doctorName = _context.DoctorsTable.Where(doctor => doctor.Doctor_Name.Contains(Doctor_Name)).ToList();
            return View("Index", doctorName);
        }

        public IActionResult SearchForm2()
        {
            return View();
        }

        //HttpPost-SearchForm()
        [HttpPost]
        public IActionResult SearchForm2(string Name)
        {
            var nurseName = _context.NursesTable.Where(nurse => nurse.Name.Contains(Name)).ToList();
            return View("Index", nurseName);
        }
        

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Hire()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Hire(DoctorsTable obj)
        {
            if (ModelState.IsValid)
            {
                _context.DoctorsTable.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Doctors");
            }
            else
                return View(obj);
        }

        public IActionResult ApplicantHire()
        {
            return View();
        }



        public async Task<IActionResult> Edit(int? id)
        {
            var doc = await _context.DoctorsTable.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(doc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(DoctorsTable obj)
        {
            if (ModelState.IsValid)
            {
                _context.DoctorsTable.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Doctors");
            }
            else
                return View(obj);
        }
        public async Task<IActionResult> Details(int? docid)
        {
            var doc = await _context.DoctorsTable.FindAsync(docid);

            if (docid == null)
            {
                return NotFound();
            }
            return View(doc);
        }

        public async Task<IActionResult> Fire(int? id)
        {
            var doc = await _context.DoctorsTable.FindAsync(id);

            if(id == null)
            {
                return NotFound();
            }
            return View(doc);
        }

        [HttpPost]
        public async Task<IActionResult> Fire(int id)
        {
            var doc = await _context.DoctorsTable.FindAsync(id);
            _context.DoctorsTable.Remove(doc);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
