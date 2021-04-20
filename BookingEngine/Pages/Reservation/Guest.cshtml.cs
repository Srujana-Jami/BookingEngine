using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookingEngine.Models;

namespace BookingEngine.Pages.Reservation
{
    public class GuestModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        [BindProperty]
        public int RoomId { get; set; }

        [BindProperty]
        public Guest Guest { get; set; }

        [BindProperty]
        public DateTime CheckinDate { get; set; }

        [BindProperty]
        public DateTime CheckoutDate { get; set; }

        [BindProperty]
        public int NumberOfAdults { get; set; }

        public GuestModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int roomId, DateTime checkinDate, DateTime checkoutDate, int numberOfAdults)
        {
            this.RoomId = roomId;
            this.CheckinDate = checkinDate;
            this.CheckoutDate = checkoutDate;
            this.NumberOfAdults = numberOfAdults;
           

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Guest.Add(Guest);

            Reservations reservation = new Reservations
            {
                CheckInDate = this.CheckinDate,
                CheckOutDate = this.CheckoutDate,
                Guest = Guest,
                RoomId = this.RoomId,
                NumberOfAdults = this.NumberOfAdults
            };
            _context.Reservations.Add(reservation);

            await _context.SaveChangesAsync();

            int guestId = Guest.GuestID;

            return RedirectToPage("./Thanks", new { reservationId = reservation.Id });

        }
    }
}
