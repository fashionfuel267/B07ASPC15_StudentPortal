using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using B07ASPC15_StudentPortal.Models;

namespace B07ASPC15_StudentPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentBasicsController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentBasicsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/StudentBasics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentBasic>>> GetStudentBasics()
        {
            return await _context.StudentBasics.ToListAsync();
        }

        // GET: api/StudentBasics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentBasic>> GetStudentBasic(int id)
        {
            var studentBasic = await _context.StudentBasics.FindAsync(id);

            if (studentBasic == null)
            {
                return NotFound();
            }

            return studentBasic;
        }

        // PUT: api/StudentBasics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentBasic(int id, StudentBasic studentBasic)
        {
            if (id != studentBasic.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentBasic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentBasicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentBasics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentBasic>> PostStudentBasic(StudentBasic studentBasic)
        {
            _context.StudentBasics.Add(studentBasic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentBasic", new { id = studentBasic.Id }, studentBasic);
        }

        // DELETE: api/StudentBasics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentBasic(int id)
        {
            var studentBasic = await _context.StudentBasics.FindAsync(id);
            if (studentBasic == null)
            {
                return NotFound();
            }

            _context.StudentBasics.Remove(studentBasic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentBasicExists(int id)
        {
            return _context.StudentBasics.Any(e => e.Id == id);
        }
    }
}
