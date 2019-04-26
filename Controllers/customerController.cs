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
    public class CustomerController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public CustomerController(RocketElevatorContext context)
        {
            _context = context;

        }
        // GET: api/Todo
        [HttpGet]
        public IEnumerable<Customer> GetCustomer()
        {
            return _context.Customers;
        }

        [HttpGet("number")]
        public int GetCustomersNumber() {
            IQueryable<Customer> Customers =
            from q in _context.Customers
            select q;

            return Customers.ToList().Count();
        }

       
    }
}