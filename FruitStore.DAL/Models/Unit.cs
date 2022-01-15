using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FruitStore.DAL.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Fruit = new HashSet<Fruit>();
        }

        public int Id { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Fruit> Fruit { get; set; }
    }
}
