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
    // [ActivatorUtilitiesConstructor]
    [ApiController]
    [Route("[controller]")]
    public class TripsController : ControllerBase
    {

        private TripContext _context; 
        //private Repository _repository;

        public TripsController(TripContext context)
        {
            _context = context;
          
        }

        [HttpGet]
        public async Task <IActionResult> GetAsync()
        {
            var trips = await _context
                .Trips.AsNoTracking()
                .ToListAsync();


                return Ok(trips);
        }

        //GET api/Trips/5 --GETS TRIPS FROM REPO
        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return _context.Trips.Find(id);
        }

        //POST api/Trips --POST(ADD) TRIP TO REPO
        [HttpPost]
        public IActionResult Post([FromBody] Trip value)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Trips.Add(value);
            _context.SaveChanges();

            return Ok(); //TODO: Can return a link where th info 
        }
        
        //PUT api/Trips/5 --PUT(UPDATE) TRIP IN REPO
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Trips.Any(t => t.Id == id) )
            {
                return NotFound();
            }
                       
            //NOTE: WHAT ABOUT NULLS???? RESOLVE LATER  
            _context.Trips.Update(value);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //DELETE api/Trips/5 --DELETE TRIP FROM REPO 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myTrip = _context.Trips.Find(id);

            if(myTrip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(myTrip);


           // _context.Remove(id);
           //
            _context.SaveChanges();

            return NoContent();
        }
        

                                 
    }
       
}
