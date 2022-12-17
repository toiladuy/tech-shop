using System;
using System.Collections.Generic;

#nullable disable

namespace Shop.Models
{
    public partial class Donation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string OrganizationName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public int Status { get; set; }
    }
}
