﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fruitables.Data;
using Fruitables.Models;

namespace Fruitables.Controllers
{
    public class OrderProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderProduct.Include(o => o.Order).Include(o => o.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderProduct == null)
            {
                return NotFound();
            }

            var orderProduct = await _context.OrderProduct
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderProduct == null)
            {
                return NotFound();
            }

            return View(orderProduct);
        }

        // GET: OrderProducts/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            return View();
        }

        // POST: OrderProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,Price,Qty")] OrderProduct orderProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", orderProduct.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", orderProduct.ProductId);
            return View(orderProduct);
        }

        // GET: OrderProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderProduct == null)
            {
                return NotFound();
            }

            var orderProduct = await _context.OrderProduct.FindAsync(id);
            if (orderProduct == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", orderProduct.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", orderProduct.ProductId);
            return View(orderProduct);
        }

        // POST: OrderProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ProductId,Price,Qty")] OrderProduct orderProduct)
        {
            if (id != orderProduct.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderProductExists(orderProduct.OrderId))
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
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", orderProduct.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", orderProduct.ProductId);
            return View(orderProduct);
        }

        // GET: OrderProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderProduct == null)
            {
                return NotFound();
            }

            var orderProduct = await _context.OrderProduct
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderProduct == null)
            {
                return NotFound();
            }

            return View(orderProduct);
        }

        // POST: OrderProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderProduct == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrderProduct'  is null.");
            }
            var orderProduct = await _context.OrderProduct.FindAsync(id);
            if (orderProduct != null)
            {
                _context.OrderProduct.Remove(orderProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderProductExists(int id)
        {
          return (_context.OrderProduct?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
