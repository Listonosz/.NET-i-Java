﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Covid.Data;
using Covid.Models;

namespace Covid.Controllers
{
    public class DatasetsController : Controller
    {
        private readonly CovidContext _context;

        public DatasetsController(CovidContext context)
        {
            _context = context;
        }

        // GET: Datasets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Datas.ToListAsync());
        }

 
        public IActionResult Wykres()
        {
            return View();

        }
        public IActionResult NewToExisting(string country)
        {
            var countrySet = _context.Datas
                .Where(b => b.countriesAndTerritories.Contains(country))
                .OrderBy(o => o.DataRep).ToList();
            
            var sells = _context.Datas
        .Where(b => b.countriesAndTerritories.Contains(country))
         .GroupBy(a => a.countriesAndTerritories)
        .Select (a => new { Amount = a.Sum(a => a.cases) })
        .ToList();
    
            var cases = countrySet.Select(o => o.cases).ToArray();
            var date = countrySet.Select(d => d.DataRep).ToArray();
            var exist = sells.Select(d => d.Amount).ToArray();
            List<object> list = new List<object>();
            list.Add(cases);
            list.Add(exist);
            list.Add(date);
            return Json(list);
        }
        // GET: Datasets/Details/
        public IActionResult Data(string country)
        {
                var countrySet = _context.Datas
                    .Where(b => b.countriesAndTerritories.Contains(country))
                    .OrderBy(o=>o.DataRep).ToList();

            var cases = countrySet.Select(o => o.cases).ToArray();
            var date = countrySet.Select(d => d.DataRep).ToArray();
            List<object> list = new List<object>();
            list.Add(cases);
            list.Add(date);
            return Json(list);
        }
        // GET: Datasets/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataset = await _context.Datas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dataset == null)
            {
                return NotFound();
            }

            return View(dataset);
        }

        // GET: Datasets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Datasets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataRep,day,month,year,cases,deaths,countriesAndTerritories,geoId,countryterritoryCode,popData2018,ContinentExp")] Dataset dataset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataset);
        }

        // GET: Datasets/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataset = await _context.Datas.FindAsync(id);
            if (dataset == null)
            {
                return NotFound();
            }
            return View(dataset);
        }

        // POST: Datasets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("ID,DataRep,day,month,year,cases,deaths,countriesAndTerritories,geoId,countryterritoryCode,popData2018,ContinentExp")] Dataset dataset)
        {
            if (id != dataset.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatasetExists(dataset.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dataset);
        }

        // GET: Datasets/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataset = await _context.Datas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dataset == null)
            {
                return NotFound();
            }

            return View(dataset);
        }

        // POST: Datasets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var dataset = await _context.Datas.FindAsync(id);
            _context.Datas.Remove(dataset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatasetExists(uint id)
        {
            return _context.Datas.Any(e => e.ID == id);
        }
    }
}
