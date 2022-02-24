﻿using Hospital_MVC.Data;
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

        public async Task<IActionResult> Nurses()
        {
            var docs = await _context.NursesTables.ToListAsync();
            return View(docs);

        }

        public async Task<IActionResult> CNAs()
        {
            var docs = await _context.CNAs.ToListAsync();
            return View(docs);
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

        public async Task<IActionResult> Nurses_Edit(int? id)
        {
            var doc = await _context.NursesTables.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(doc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Nurses_Edit(NursesTable obj)
        {
            if (ModelState.IsValid)
            {
                _context.NursesTables.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Nurses_edit");
            }
            else
                return View(obj);
        }
        public async Task<IActionResult> NursesFire(int? id)
        {
            var doc = await _context.NursesTables.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(doc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NursesFire(int id)
        {
            var doc = await _context.NursesTables.FindAsync(id);
            _context.NursesTables.Remove(doc);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Nurses_Details(int? docid)
        {
            var doc = await _context.NursesTables.FindAsync(docid);

            if (docid == null)
            {
                return NotFound();
            }
            return View(doc);
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
        [ValidateAntiForgeryToken]
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


        public async Task<IActionResult> CNAs_Edit(int? id)
        {
            var doc = await _context.CNAs.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(doc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CNAs_Edit(CNAs obj)
        {
            if (ModelState.IsValid)
            {
                _context.CNAs.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("CNAs_Edit");
            }
            else
                return View(obj);
        }
        public async Task<IActionResult> CNAs(int? id)
        {
            var doc = await _context.NursesTables.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(doc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CNAs_Fire(int id)
        {
            var doc = await _context.CNAs.FindAsync(id);
            _context.CNAs.Remove(doc);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CNAs_Details(int? docid)
        {
            var doc = await _context.CNAs.FindAsync(docid);

            if (docid == null)
            {
                return NotFound();
            }
            return View(doc);
        }
    }
}
