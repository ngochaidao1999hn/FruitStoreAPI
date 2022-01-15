using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FruitStore.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cart = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public string Addr { get; set; }
        public string Phonenumber { get; set; }
        public string Pwd { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
    }
}
