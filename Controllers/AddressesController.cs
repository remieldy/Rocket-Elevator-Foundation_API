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
    public class AddressesController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public AddressesController(RocketElevatorContext context)
        {
            _context = context;
        } 

            [HttpGet]
        public IEnumerable<Addresses> GetAddresses()
        {
            return _context.Addresses;
        }

}  } 