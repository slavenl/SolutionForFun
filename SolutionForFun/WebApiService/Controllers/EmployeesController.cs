using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiService.Contracts.Models;
using WebApiService.Infrastructure;

namespace WebApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[DisableCors]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesDBContext _context;

        public EmployeesController(EmployeesDBContext context)
        {
            _context = context;
            Log.Information("Service - Created");

        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            Log.Information("Service - GetEmployees");


            _context.Database.EnsureCreated();

            List<Employee> lista = _context.Employees.Include(a => a.EmployeeData).ToList();

            return lista;
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

            Employee employee = _context.Employees.Include(a => a.EmployeeData).Where(x => x.EmployeeId == id).First();

            await Task.CompletedTask;

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5  //update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            Log.Information($"Service - PutEmployee({id})");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            Employee existing = _context.Employees.Find(id);

            _context.Entry(existing).CurrentValues.SetValues(employee);

            //_context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
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

        // POST: api/Employees //insert
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        {
            Log.Information($"Service - PostEmployee");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Employees.Add(employee);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"Error occured: {ex.InnerException}", ex);
                throw;
            }

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
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

            Employee employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
