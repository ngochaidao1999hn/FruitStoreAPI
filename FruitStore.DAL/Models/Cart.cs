using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FruitStore.DAL.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartDetail = new HashSet<CartDetail>();
        }

        public int Id { get; set; }
        public int? CusId { get; set; }
        public DateTime create_date { get; set; }
        public virtual Customer Cus { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }
    }
}
