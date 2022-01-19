using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //api/users
        [AllowAnonymous]
        [HttpGet]
        public async Task< ActionResult<IEnumerable<AppUser>> > GetUsers()
        {
            var users = _context.Users.ToListAsync();
            return await users;
        }

        //api/users/1
        [Authorize]
        [HttpGet("{id}")]
        public async Task< ActionResult<AppUser> > GetUsers(int id)
        {
            var user = _context.Users.FindAsync(id);
            return await user;
        }
    }
}