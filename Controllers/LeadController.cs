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
    public class LeadController : ControllerBase {
        private readonly RocketElevatorContext _context;

        public LeadController(RocketElevatorContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Lead> GetLeads() {
            return _context.Leads;
        }
    }
}