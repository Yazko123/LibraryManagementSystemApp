using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    internal class Reservation
    {
        
        public class Reservation
        {
            public int Id { get; set; }

            public Member Member { get; set; }

            public Book Book { get; set; }

            public DateTime ReservationDate { get; set; }

            public DateTime ExpirationDate { get; set; }

            public bool IsActive { get; set; }

            public Reservation()
            {
                ReservationDate = DateTime.Now;
                ExpirationDate = DateTime.Now.AddDays(7);
                IsActive = true;
            }

            public bool IsExpired()
            {
                return DateTime.Now > ExpirationDate;
            }

            public void CancelReservation()
            {
                IsActive = false;
            }

            public bool CanBorrow()
            {
                return IsActive && !IsExpired();
            }

            public int DaysRemaining()
            {
                return (ExpirationDate - DateTime.Now).Days;
            }
        }
    }
}

