using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BugZila.Data;
using BugZila.Models;

namespace BugZila.Components.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BugZila.Data.ApplicationDbContext _context;

        public IndexModel(BugZila.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
