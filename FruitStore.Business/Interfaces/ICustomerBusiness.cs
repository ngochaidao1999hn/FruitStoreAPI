using FruitStore.DAL.Models;
using FruitStore.DTOS.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Business.Interfaces
{
    public interface ICustomerBusiness:IRepository<Customer>
    {
        public Task<object> Authenticate(LoginRequest loginRequest);
        public Task<bool> Register(RegisterRequest registerRequest);
    }
}
