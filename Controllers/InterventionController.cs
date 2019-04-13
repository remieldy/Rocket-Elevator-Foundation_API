using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySql.Data.MySqlClient;

using RocketElevatorApi.Models;

namespace RocketElevatorApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionController : ControllerBase {
        private readonly RocketElevatorContext _context;

        public InterventionController(RocketElevatorContext context) {
            _context = context;

            // if (_context.Elevators.Count() == 0) {
            //     // Create a new TodoItem if collection is empty,
            //     // which means you can't delete all TodoItems.
            //     _context.Elevators.Add(new Elevator { Name = "Item1" });
            //     _context.SaveChanges();
            // }
        }

        [HttpGet]
        public IEnumerable<Intervention> GetAllInterventions() {
            return _context.Interventions;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> GetTodoItems(long id) {
            var todoItem = await _context.Interventions.FindAsync(id);

            if (todoItem == null) {
                return NotFound();
            }

            return todoItem;
        }

        // GET: api/building
        [HttpGet("pending")]
        public IEnumerable<Intervention> GetInterventionNotStarted() {
            IQueryable<Intervention> Intervention =
            from i in _context.Interventions
            where i.intervention_start == null && i.status == "pending"
            select i;
            return Intervention.ToList();
        }

        // PUT: api/intervention/id
       [HttpPut("{id}")]
       public async Task<IActionResult> PutTodoItem(long id, Intervention item) {
           if (id != item.id) {
               return BadRequest();
           }

           if (item.status == "InProgress" || item.status == "Completed")
           {
               if (item.status == "InProgress"){

                   item.intervention_finish = null;
                   item.intervention_start = DateTime.Now;
                   _context.Entry(item).State = EntityState.Modified;
                   await _context.SaveChangesAsync();
                   return Content("Intervention: " + item.id + ", status as been changed to: " + item.status + ", and intervention_start as been changed to: " + item.intervention_start);
               }
               if (item.status == "Completed"){

                   item.intervention_finish = DateTime.Now;
                   _context.Entry(item).State = EntityState.Modified;
                   await _context.SaveChangesAsync();
                   return Content("Intervention: " + item.id + ", status as been changed to: " + item.status + ", and intervention_finish as been changed to: " + item.intervention_finish);
               }
           }

           return Content("You need to insert a valid status : Pending, InProgress, Completed, Thank you !  ");

       }
}