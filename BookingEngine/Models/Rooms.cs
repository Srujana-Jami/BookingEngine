using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingEngine.Models
{
    public class Rooms
    {
        [Key]
        public int RoomID { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double Taxes { get; set; }
        public double TotalPrice { get; set; }
       
        [NotMapped]
        public string Base64Image { get; set; }
        public byte[] ByteArrayImage { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
