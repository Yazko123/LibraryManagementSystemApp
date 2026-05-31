using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    internal class Fine
    {
    
        public class Fine
        {
            public int Id { get; set; }

            public Member Member { get; set; }

            public Loan Loan { get; set; }

            public decimal Amount { get; set; }

            public bool IsPaid { get; set; }

            public DateTime CreatedDate { get; set; }

            public Fine()
            {
                CreatedDate = DateTime.Now;
                IsPaid = false;
            }

            public decimal CalculateFine()
            {
                if (Loan == null)
                {
                    return 0;
                }

                int overdueDays = Loan.GetOverdueDays();

                if (overdueDays <= 0)
                {
                    Amount = 0;
                }
                else
                {
                    Amount = overdueDays * 0.50m;
                }

                return Amount;
            }

            public void PayFine()
            {
                IsPaid = true;
            }

            public bool HasUnpaidFine()
            {
                return !IsPaid && Amount > 0;
            }
        }
    }
}
