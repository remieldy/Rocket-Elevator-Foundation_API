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

        // GET: api/building
        [HttpGet]
        public IEnumerable<Intervention> GetIntervention() {
            IQueryable<Intervention> Intervention =
           from i in _context.Interventions
           where i.intervention_start == null && i.status == "pending"
           select i;
            return Intervention.ToList();
        }

        // GET: api/building/5
        [HttpGet("intervention")]
        public IEnumerable<Building> GetBuildingsIntervention() {
            //Starting a query in lambda 
            //This query look for each Battery, Columns and Elevators that have a status set to Intervention 
            //and return the corresponding Building informations.
            IQueryable<Building> Building =
                from bu in _context.Buildings
                join ba in _context.Batteries on bu.id equals ba.building_id
                join co in _context.Columns on ba.id equals co.battery_id
                join el in _context.Elevators on co.id equals el.column_id
            where ba.status == "Intervention" || co.status == "Intervention" || el.status == "Intervention"
            select bu;

            //Return the IQueryable Building lambda as a list. 
            return Building.ToList();
        }
// PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Intervention item) {
            if (id != item.id) {
                return BadRequest();
            }
            
            if (item.status == "Intervention" || item.status == "InProgress" || item.status == "Completed")
            {
                if(item.intervention_start != null) 
                {
                    item.intervention_start = DateTime.Now;
                     _context.Entry(item).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Content("Intervention: " + item.id + ", status as been changed to: " + item.status + ", and intervention_start as been changed to: " + item.intervention_start);
                }
                else
                {
                    item.intervention_finish = DateTime.Now;
                     _context.Entry(item).State = EntityState.Modified;
                     await _context.SaveChangesAsync();
                    return Content("Intervention: " + item.id + ", status as been changed to: " + item.status + ", and intervention_finish as been changed to: " + item.intervention_finish);
                    
                }
            }

            return Content("You need to insert a valid status : Pending, InProgress, Completed, Thank you !  ");

        }
    }
}
