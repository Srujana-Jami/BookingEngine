using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingEngine.Data;
using BookingEngine.Models;

namespace BookingEngine.Pages.Reservation
{
    public class AdminModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        public AdminModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        public IList<Reservations> Reservations { get; set; }
        public IList<Guest> Guest { get; set; }
        public IList<Rooms> Rooms { get; set; }

        public async Task OnGetAsync()
        {
            Reservations = await _context.Reservations
                .Include(r => r.Guest)
                .Include(r => r.Room).ToListAsync();

        }
        
    }
}
