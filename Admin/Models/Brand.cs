using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Tilte { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
