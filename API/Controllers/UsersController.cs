using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //api/users
        [HttpGet]
        public async Task< ActionResult<IEnumerable<AppUser>> > GetUsers()
        {
            var users = _context.Users.ToListAsync();
            return await users;
        }

        //api/users/1
        [HttpGet("{id}")]
        public async Task< ActionResult<AppUser> > GetUsers(int id)
        {
            var user = _context.Users.FindAsync(id);
            return await user;
        }
    }
}