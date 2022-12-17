using System;
using System.Collections.Generic;

#nullable disable

namespace Shop.Models
{
    public partial class UserDonation
    {
        public int UserId { get; set; }
        public int DonationId { get; set; }
        public string Name { get; set; }
        public double? Money { get; set; }
        public DateTime? CreateAt { get; set; }
        public string Status { get; set; }

        public virtual Donation Donation { get; set; }
    }
}
