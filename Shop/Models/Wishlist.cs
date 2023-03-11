using System;

namespace Shop.Models
{
    public partial class Wishlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreateAt { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
