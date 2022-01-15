using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FruitStore.DAL.Models
{
    public partial class CartDetail
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public int? ProId { get; set; }
        public int? Quantity { get; set; }
        public bool? Ispaid { get; set; }
        public double? Pric { get; set; }
        public int? OrderStatus { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Fruit Pro { get; set; }
    }
}
