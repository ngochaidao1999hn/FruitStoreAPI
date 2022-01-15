using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.DTOS.CustomerDTOs
{
    public class RegisterRequest
    {
        public string Pwd { get; set; }
        public string Addr { get; set; }
        public string Phonenumber { get; set; }

    }
}
