using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Models;
using TripTracker.UI.Data;

namespace TripTracker.UI
{
    public class DeleteModel : PageModel
    {
        private readonly TripTracker.UI.Data.ApplicationDbContext _context;

        public DeleteModel(TripTracker.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DesktopComputer DesktopComputer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DesktopComputer = await _context.DesktopComputer.FirstOrDefaultAsync(m => m.Id == id);

            if (DesktopComputer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DesktopComputer = await _context.DesktopComputer.FindAsync(id);

            if (DesktopComputer != null)
            {
                _context.DesktopComputer.Remove(DesktopComputer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
