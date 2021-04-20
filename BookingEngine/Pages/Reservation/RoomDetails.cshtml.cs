using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingEngine.Models;

namespace BookingEngine.Pages.Reservation
{
    public class RoomDetailsModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        public RoomDetailsModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        public Rooms Room { get; set; }
        
        [BindProperty]
        public DateTime CheckinDate { get; set; }

        [BindProperty]
        public DateTime CheckoutDate { get; set; }

        [BindProperty]
        public int NumberOfAdults { get; set; }
       
        public async Task OnGetAsync(int roomId, DateTime checkinDate, DateTime checkoutDate, int numberOfAdults)
        {
            this.CheckinDate = checkinDate;
            this.CheckoutDate = checkoutDate;
            this.NumberOfAdults = numberOfAdults;
            
            if (roomId == 0)
            {
                return;
            }
           
            var room = await _context.Rooms.Where(s => s.RoomID == roomId).FirstOrDefaultAsync();

            room.Base64Image = $"data:image/png;base64,{Convert.ToBase64String(room.ByteArrayImage)}";

            Room = room;
        }
    }
}
