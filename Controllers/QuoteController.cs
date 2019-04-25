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
    public class QuoteController : ControllerBase {
        private readonly RocketElevatorContext _context;

        public QuoteController(RocketElevatorContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Quote> GetQuotes() {
            return _context.Quotes;
        }

        [HttpGet("number")]
        public int GetQuotesNumber() {
            IQueryable<Quote> Quotes =
            from q in _context.Quotes
            select q;

            return Quotes.ToList().Count();
        }
    }
}