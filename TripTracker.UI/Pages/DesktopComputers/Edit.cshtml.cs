using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Models;
using TripTracker.UI.Data;

namespace TripTracker.UI
{
    public class EditModel : PageModel
    {
        private readonly TripTracker.UI.Data.ApplicationDbContext _context;

        public EditModel(TripTracker.UI.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DesktopComputer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesktopComputerExists(DesktopComputer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DesktopComputerExists(int id)
        {
            return _context.DesktopComputer.Any(e => e.Id == id);
        }
    }
}
