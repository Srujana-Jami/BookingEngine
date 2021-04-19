using System;
using System.ComponentModel.DataAnnotations;

namespace BookingEngine.Models
{
    public class Reservations
    {
        [Key]
        
        public int Id { get; set; }
        public int RoomId { get; set; }

        public int GuestId { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        public int NumberOfAdults { get; set; }
        public virtual Rooms Room { get; set; }

        public virtual Guest Guest { get; set; }

    }
}
