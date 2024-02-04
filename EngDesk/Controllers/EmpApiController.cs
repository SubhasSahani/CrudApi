using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EngDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace EngDesk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpApiController : ControllerBase
    {
        private readonly EngineerDeskContext _context;
        public EmpApiController(EngineerDeskContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmplyee()
        {
            var data = await _context.Employees.ToListAsync();
            return Ok(data);
        }

         [HttpGet("{id}")]
        public  async Task<ActionResult<Employee>> GetEmplyeebyid(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            
            }
            return employee;
        }
        [HttpPost]
        public  async Task<ActionResult<Employee>> CreateEmplyee(Employee emp)
        {
            await  _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();
            return Ok(emp);
        }
        [HttpPut("{id}")]
        public  async Task<ActionResult<Employee>> UpdateEmplyee(int id, Employee emp)
        {
            if(id != emp.Employeeid )
            {
                return BadRequest();
            }
            _context.Entry(emp).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(emp);
        }
        [HttpDelete("{id}")]
        public  async Task<ActionResult<Employee>> DeleteEmplyee(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if( emp == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}