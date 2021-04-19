using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingEngine.Models
{
    public class Guest
    {
        [Key]
        public int GuestID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HomeAddress { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public string CreditCardNumber { get; set; }

        public string FullNameOnCard { get; set; }

        [DataType(DataType.Date)]
        
        public DateTime ExpiryDate { get; set; }

        public int CVV { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
