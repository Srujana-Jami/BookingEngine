using System;
using System.Linq;
using System.Threading.Tasks;
using BookingEngine.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookingEngine.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingEngine.Pages.Reservation
{
    public class ThanksModel : PageModel
    {
        private readonly BookingEngineContext _ctx;
        public ThanksModel(BookingEngineContext ctx)
        {
            this._ctx = ctx;
        }
       
        [BindProperty]
        public Rooms BookedRoom { get; set; }

        [BindProperty]
        public Guest BookedByGuest { get; set; }
       
        public async Task OnGet(int reservationId)
        {
             var reservation = _ctx.Reservations
                                    .Include(res => res.Room)
                                    .Include(res => res.Guest)
                                    .FirstOrDefault(r => r.Id == reservationId);

            if (reservation == null)
            {
                return;
            }
          
            BookedRoom = reservation.Room;

            BookedByGuest = reservation.Guest;

            BookedRoom.Base64Image = $"data:image/png;base64,{Convert.ToBase64String(BookedRoom.ByteArrayImage)}";
        }
    }
}
