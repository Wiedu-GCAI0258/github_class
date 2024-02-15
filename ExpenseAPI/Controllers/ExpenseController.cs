// 這個 api 會使用 Expense.cs 這個 Entity  來對應到資料庫中的一個 Table
// 這個 api 會使用 ExpenseContext.cs 這個 DbContext 來對應到資料庫
// api 的路徑是 /api/expense

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseAPI.Models;

namespace ExpenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseContext _context;

        public ExpenseController(ExpenseContext context)
        {
            _context = context;
        }

        // GET: api/Expense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpenseItems()
        {
            return await _context.ExpenseItems.ToListAsync();
        }

        // GET: api/Expense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            var expense = await _context.ExpenseItems.FindAsync(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }

        // PUT: api/Expense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }

            return NoContent();
        }

        // POST: api/Expense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        //q: 提供 curl 呼叫的範例
        // curl -X POST "http://localhost:7238/api/Expense" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"date\":\"2021-10-01T00:00:00\",\"description\":\"test\",\"amount\":100}"
        // 如果 desctiption 是 午餐，則回傳 400 Bad Request 並且回傳 "買午餐不可以報帳"
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            if (expense == null)
            {
                return BadRequest("Expense object is null.");
            }

            if (string.IsNullOrEmpty(expense.Description))
            {
                return BadRequest("Expense description is required.");
            }

            if (expense.Amount <= 0)
            {
                return BadRequest("Expense amount must be greater than zero.");
            }

            if (expense.Description == "午餐")
            {
                return BadRequest("買午餐不可以報帳");
            }
            
            _context.ExpenseItems.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
        }

        // DELETE: api/Expense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var expense = await _context.ExpenseItems.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.ExpenseItems.Remove(expense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseExists(int id)
        {
            return _context.ExpenseItems.Any(e => e.Id == id);
        }
    }
}



