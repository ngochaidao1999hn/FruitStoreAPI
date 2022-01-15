using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FruitStore.DAL.Models
{
    public partial class Fruit
    {
        public Fruit()
        {
            CartDetail = new HashSet<CartDetail>();
        }

        public int Id { get; set; }
        public string FruitName { get; set; }
        public double? Price { get; set; }
        public DateTime? ImpDate { get; set; }
        public string Descrip { get; set; }
        public int? Quantity { get; set; }
        public bool? IsImported { get; set; }
        public string Img { get; set; }
        public int? IdCate { get; set; }
        public int? IdUnit { get; set; }
        public int? IdOrigin { get; set; }

        public virtual Categories IdCateNavigation { get; set; }
        public virtual Origin IdOriginNavigation { get; set; }
        public virtual Unit IdUnitNavigation { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }
    }
}
