using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker1.Models;

namespace ExpenseTracker1.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expense
        //Enable filtering by date or category on the Index page

        public IActionResult Index(string category, DateTime? startDate, DateTime? endDate)
        {
            // Query all expenses
            var expenses = _context.TransactionsExpenses.AsQueryable();

            // Check if the database has any records at all
            bool isDatabaseEmpty = !_context.TransactionsExpenses.Any();

            if (isDatabaseEmpty)
            {
                ViewData["NoItemsMessage"] = "No items are available currently. Please add an item.";
                return View(new List<Expense>()); // Return an empty list to the view
            }

            // Apply filters if parameters are provided
            if (!string.IsNullOrEmpty(category))
            {
                expenses = expenses.Where(e => e.Category == category);
                ViewData["CurrentCategory"] = category; // Retain category filter
            }

            if (startDate.HasValue)
            {
                expenses = expenses.Where(e => e.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                expenses = expenses.Where(e => e.Date <= endDate.Value);
            }

            // Check if no results are found
            if (!expenses.Any())
            {
                ViewData["NoItemsMessage"] = "No items found matching your criteria.";
            }
            return View(expenses.ToList());
        }


        // GET: Expense/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransactionsExpenses == null)
            {
                return NotFound();
            }

            var expense = await _context.TransactionsExpenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // Summary Action
        public IActionResult Summary()
        {
            // Group expenses by category and calculate the total amount for each category
            var summary = _context.TransactionsExpenses
                .GroupBy(e => e.Category)
                .Select(group => new ExpenseSummary
                {
                    Category = group.Key,
                    TotalAmount = group.Sum(e => e.Amount)
                }).ToList();

            return View(summary);
        }

        // GET: Expense/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expense/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Amount,Category,Date")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: Expense/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransactionsExpenses == null)
            {
                return NotFound();
            }

            var expense = await _context.TransactionsExpenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,Category,Date")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
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
            return View(expense);
        }

        // GET: Expense/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransactionsExpenses == null)
            {
                return NotFound();
            }

            var expense = await _context.TransactionsExpenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransactionsExpenses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TransactionsExpenses'  is null.");
            }
            var expense = await _context.TransactionsExpenses.FindAsync(id);
            if (expense != null)
            {
                _context.TransactionsExpenses.Remove(expense);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
          return (_context.TransactionsExpenses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
