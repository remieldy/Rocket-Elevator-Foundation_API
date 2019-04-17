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
 [HttpGet("{email}")]


        // GET: api/building
        [HttpGet]
        public IEnumerable<User> GetUsers() {
            return _context.Users;
        }
     public Boolean FindUsersByEmail(string email) {
            // IQueryable<User> item = await _context.Users.Where(x=> (x.email == current_email)).ToList();
            IQueryable<User> AskedUsers =
                from user in _context.Users
            where user.email == email
            select user;

            var answer = false;

            if (AskedUsers.ToList().Any()) {
                answer = true;
            }
            return answer;

        }
      
    }
}