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
    public class UsersController : ControllerBase {
        private readonly RocketElevatorContext _context;

        public UsersController(RocketElevatorContext context) {
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
        public IEnumerable<User> GetUsers() {
            return _context.Users;
        }

        [HttpGet("{email}")]
        public Boolean FindUser(string current_email) {
            IQueryable<User> UsersList =
                from emp in _context.Users
            where emp.email == current_email
            select emp;

            var answer = false;

            if (UsersList != null) {
                answer = true;
            }
            return answer;
        }
      
    }
}