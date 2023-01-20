using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamPlayers.Data;

namespace TeamPlayers.Pages_TeamPages
{
    public class DetailsModel : PageModel
    {
        private readonly TeamPlayers.Data.ApplicationDbContext _context;

        public DetailsModel(TeamPlayers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Team Team { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FirstOrDefaultAsync(m => m.TeamName == id);
            if (team == null)
            {
                return NotFound();
            }
            else 
            {
                Team = team;
            }
            return Page();
        }
    }
}
