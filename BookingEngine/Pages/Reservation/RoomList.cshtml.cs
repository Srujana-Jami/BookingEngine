using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingEngine.Models;
using BookingEngine.Data;

namespace BookingEngine.Pages.Reservation
{
    public class RoomListModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        public RoomListModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        public IList<Rooms> Rooms { get;set; }
        
        [BindProperty]
        public DateTime CheckinDate { get; set; }

        [BindProperty]
        public DateTime CheckoutDate { get; set; }

        [BindProperty]
        public int NumberOfAdults { get; set; }
       
        public async Task OnGetAsync(DateTime checkinDate, DateTime checkoutDate, int numberOfAdults)
        {

            this.CheckinDate = checkinDate;
            this.CheckoutDate = checkoutDate;
            this.NumberOfAdults = numberOfAdults;

            var bookedRoomIds = await _context.Reservations
                                           .Where(r => checkinDate <= r.CheckInDate && r.CheckOutDate <= checkoutDate)
                                           .Select(x => x.RoomId)
                                           .ToListAsync();

            var rooms = await _context.Rooms
                .Where(r=>bookedRoomIds.Contains(r.RoomID)==false)
                .ToListAsync();
           
            foreach (var room in rooms)
            {
                room.Base64Image = $"data:image/png;base64,{Convert.ToBase64String(room.ByteArrayImage)}";
            }
            Rooms = rooms;
        }
    }
}
