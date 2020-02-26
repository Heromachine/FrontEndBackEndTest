using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TripTracker.BackService.Models;
using TripTracker.BackService.Data;


namespace TripTracker.BackService.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class DesktopComputersController : ControllerBase
    {
        private DesktopComputerContext _context;

        public DesktopComputersController(DesktopComputerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var desktopComputers = await _context.DesktopComputers.AsNoTracking().ToListAsync();
            return Ok(desktopComputers);
        }
        

        [HttpGet("{id}")]
        public DesktopComputer Get(int id)
        {
            return _context.DesktopComputers.Find(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DesktopComputer value)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            _context.DesktopComputers.Add(value);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]DesktopComputer value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            if(!_context.DesktopComputers.Any(d => d.Id == id))
            {
                return NotFound();
            }

            _context.DesktopComputers.Update(value);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var computer = _context.DesktopComputers.Find(id);

            if(computer == null)
            {
                return NotFound();
            }

            _context.DesktopComputers.Remove(computer);

            _context.SaveChanges();
            return NoContent();       
        }



        
    }
}
