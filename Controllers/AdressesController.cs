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
    public class AdressesController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public AdressesController(RocketElevatorContext context)
        {
            _context = context;
        } 

            [HttpGet]
        public IEnumerable<Adresses> GetAdresses()
        {
            return _context.Adresses;
        }

}  } 