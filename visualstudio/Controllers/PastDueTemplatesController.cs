using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using visualstudio.Models;

namespace visualstudio.Controllers
{
    public class PastDueTemplatesController : Controller
    {
        private readonly EmailContext _context;

        public PastDueTemplatesController(EmailContext context)
        {
            _context = context;    
        }

        // GET: PastDueTemplates
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmailTemplate.ToListAsync());
        }

        // GET: PastDueTemplates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pastDueTemplate = await _context.EmailTemplate
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pastDueTemplate == null)
            {
                return NotFound();
            }

            return View(pastDueTemplate);
        }

        // GET: PastDueTemplates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PastDueTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Intro,Body,Closing")] PastDueTemplate pastDueTemplate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pastDueTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pastDueTemplate);
        }

        // GET: PastDueTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pastDueTemplate = await _context.EmailTemplate.SingleOrDefaultAsync(m => m.Id == id);
            if (pastDueTemplate == null)
            {
                return NotFound();
            }
            return View(pastDueTemplate);
        }

        // POST: PastDueTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Intro,Body,Closing")] PastDueTemplate pastDueTemplate)
        {
            if (id != pastDueTemplate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pastDueTemplate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PastDueTemplateExists(pastDueTemplate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(pastDueTemplate);
        }

        // GET: PastDueTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pastDueTemplate = await _context.EmailTemplate
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pastDueTemplate == null)
            {
                return NotFound();
            }

            return View(pastDueTemplate);
        }

        // POST: PastDueTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pastDueTemplate = await _context.EmailTemplate.SingleOrDefaultAsync(m => m.Id == id);
            _context.EmailTemplate.Remove(pastDueTemplate);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PastDueTemplateExists(int id)
        {
            return _context.EmailTemplate.Any(e => e.Id == id);
        }

        public async Task<IActionResult> PastDue()
        {


            var emailList = await _context.EmailTemplate.ToListAsync();

            ViewBag.ListOfEmails = emailList;

            return View(emailList.First());
        }

        [HttpPost]
        public async Task<IActionResult> PastDue(PastDueTemplate email)
        {


            var emailList = await _context.EmailTemplate.ToListAsync();

            if (email == null)
            {
                email = emailList.First();
            }
            else
            {
                email = emailList.Where(x => x.Id == email.Id).First();
            }

            ViewBag.ListOfEmails = emailList;

            return View(email);
        }
        }
}
