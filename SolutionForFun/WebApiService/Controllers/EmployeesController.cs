using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApiService.Contracts.Models;
using WebApiService.Infrastructure;

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[DisableCors]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController()
        {
            Log.Information("Service - Created");
            //  _context = null;

        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> Gettblemployee()
        {
            Log.Information("Service - Gettblemployee");

            List<Employee> lista = new List<Employee>() { new Employee() { email = "nesto", ID = 1, Fname = "Slaven", Lname = "Lukic", gender = "1" } };

            return lista;// _context.tblemployee;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            Log.Information($"Service - GetEmployee({id})");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.tblemployee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            Log.Information($"Service - PutEmployee({id})");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.ID)
            {
                return BadRequest();
            }

            //  _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) //DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        {
            Log.Information($"Service - PostEmployee");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tblemployee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.ID }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            Log.Information($"Service - DeleteEmployee({id})");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.tblemployee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.tblemployee.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _context.tblemployee.Any(e => e.ID == id);
        }
    }
}
