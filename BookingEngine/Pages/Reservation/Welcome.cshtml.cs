using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookingEngine.Models;

namespace BookingEngine.Pages.Reservation
{
    public class WelcomeModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        public WelcomeModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            TodaysDate = DateTime.Today.ToString("yyyy-MM-dd");
            return Page();
        }

        [BindProperty]
        public Reservations Reservations { get; set; }

        [BindProperty]
        public string TodaysDate { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./RoomList", new
            {
                CheckInDate = Reservations.CheckInDate,
                CheckoutDate = Reservations.CheckOutDate,
                NumberOfAdults = Reservations.NumberOfAdults
            });
        }
    }
}
