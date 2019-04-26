using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RocketElevatorApi.Models;

namespace RocketElevatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlexaController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public AlexaController(RocketElevatorContext context)
        {
            _context = context;
        } 

        [HttpGet("elevators")]
        public IEnumerable<Elevator> GetElevators() {
            return _context.Elevators;
        }
            [HttpGet("ElevatorsStatus")]
        public IEnumerable<Elevator> GetElevatorsStatus() {
            IQueryable<Elevators> ElevatorStatus =
            from ele in _context.Elevators
            where ele.status == "Moving"
            select ele;
            return ElevatorStatus.ToList();
        }

            [HttpGet("Addresses/cities")]
        public IEnumerable<Addresses> GetAddresses() {
            IQueryable<Address> Address =
                from ba in _context.Batteries
                join bu in _context.Buildings on ba.building_id equals bu.id
                join ad in _context.Addresses on bu.address_id equals ad.id
            where ba.status == "Active"
            select ad;
            return Address.ToList().Dinstinct();
        }
                    [HttpGet("buildings")]
        public IEnumerable<Buildings> GetBuildings()
        {
            return _context.Buildings;
        }

                   [HttpGet("Batteries")]
        public IEnumerable<Batteries> GetBatteries()
        {
            return _context.Batteries;
        }
        
                   [HttpGet("Leads")]
        public IEnumerable<Leads> GetLeads()
        {
            return _context.Leads;
        }
          
                   [HttpGet("Quotes")]
        public IEnumerable<Quotes> GetQuote()
        {
            return _context.Quotes;
        }
                    [HttpGet("customers")]
        public IEnumerable<customers> GetCustomers()
        {
            return _context.customers;
        }



       

     

}  } 
