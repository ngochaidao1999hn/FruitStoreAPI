using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.DTOS.CustomerDTOs
{
    public class LoginRequest
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
