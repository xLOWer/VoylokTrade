using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VoylokTrade.Models;

namespace VoylokTrade.Controllers
{
    public class GoodsController : Controller
    {
        private readonly VoylokTradeDbContext _context;

        public GoodsController(VoylokTradeDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> MassAdding(string str)
        {
            //var str = obj;

            Regex reg = new Regex("^123", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            MatchCollection match = reg.Matches(str);

            

            return await ListForCustomer();
        }

        public IActionResult MassAddingList()
        {
            return View("MassAddingList");
        }

        // GET: Goods
        public async Task<IActionResult> Index()
        {
            return await ListForCustomer();
        }
        // GET: Goods
        public async Task<IActionResult> ListForOur()
        {
            return View(await _context.Goods.ToListAsync());
        }

        // GET: Goods
        public async Task<IActionResult> ListForCustomer()
        {
            return View(await _context.Goods.ToListAsync());
        }
        // GET: Goods/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .SingleOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // GET: Goods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,TareVolume,PricePerGood,Manufacturer,Weight,WeightType,PriceMarkupInPercent,Id,TimeStamp")] Good good)
        {
            if (ModelState.IsValid)
            {
                good.Id = Guid.NewGuid();
                _context.Add(good);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListForOur));
            }
            return View(good);
        }

        // GET: Goods/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods.SingleOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }
            return View(good);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,TareVolume,PricePerGood,Manufacturer,Weight,WeightType,PriceMarkupInPercent,Id,TimeStamp")] Good good)
        {
            if (id != good.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(good);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodExists(good.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListForOur));
            }
            return View(good);
        }

        // GET: Goods/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .SingleOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var good = await _context.Goods.SingleOrDefaultAsync(m => m.Id == id);
            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListForOur));
        }

        private bool GoodExists(Guid id)
        {
            return _context.Goods.Any(e => e.Id == id);
        }
    }
}
