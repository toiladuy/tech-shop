using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Admin.Models
{
    public partial class Role
    {
        public Role()
        {
            Credentials = new HashSet<Credential>();
            Users = new HashSet<User>();
        }

        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        public virtual ICollection<Credential> Credentials { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
