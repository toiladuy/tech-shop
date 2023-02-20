using System;

namespace Shop.Models
{
    public partial class UserActivation
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public int Status { get; set; }
        public virtual User User { get; set; }

        public UserActivation()
        {
            Code = System.Guid.NewGuid().ToString();
            ExpiredAt = DateTime.Now.AddDays(1);
            Status = 0;
        }
    }
}
