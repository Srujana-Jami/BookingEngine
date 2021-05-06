using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingEngine.Data;
using BookingEngine.Models;

namespace BookingEngine.Pages.Reservation
{
    public class GuestEditModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        public GuestEditModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guest Guest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Guest = await _context.Guest.FirstOrDefaultAsync(m => m.GuestID == id);

            if (Guest == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Guest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(Guest.GuestID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Updated");
        }

        private bool GuestExists(int id)
        {
            return _context.Guest.Any(e => e.GuestID == id);
        }
    }
}
