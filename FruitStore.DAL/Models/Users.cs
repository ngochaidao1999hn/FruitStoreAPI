using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FruitStore.DAL.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pwd { get; set; }
    }
}
