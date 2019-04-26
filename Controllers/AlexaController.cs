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

        [HttpGet("Elevators")]
        public IEnumerable<Elevator> GetElevators() {
            return _context.Elevators;
        }
            [HttpGet("ElevatorsStatus")]
        public IEnumerable<Elevator> GetElevatorsStatus() {
            IQueryable<Elevator> ElevatorStatus =
            from ele in _context.Elevators
            where ele.status == "Moving"
            select ele;
            return ElevatorStatus.ToList();
        }

            [HttpGet("Address/cities")]
        public IEnumerable<Address> GetAddresses() {
            IQueryable<Address> AddressesList =
                from ba in _context.Batteries
                join bu in _context.Buildings on ba.building_id equals bu.id
                join ad in _context.Addresses on bu.address_id equals ad.id
            where ba.status == "Online"
            select ad;
            return AddressesList.Distinct().ToList();
        }
                    [HttpGet("Buildings")]
        public IEnumerable<Building> GetBuildings()
        {
            return _context.Buildings;
        }

                   [HttpGet("Batteries")]
        public IEnumerable<Battery> GetBatteries()
        {
            return _context.Batteries;
        }
        
                   [HttpGet("Leads")]
        public IEnumerable<Lead> GetLeads()
        {
            return _context.Leads;
        }
          
                   [HttpGet("Quotes")]
        public IEnumerable<Quote> GetQuotes()
        {
            return _context.Quotes;
        }
                    [HttpGet("customers")]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

     

}  } 
