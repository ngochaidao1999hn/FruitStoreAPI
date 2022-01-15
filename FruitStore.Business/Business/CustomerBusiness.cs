using FruitStore.Business.Interfaces;
using FruitStore.DAL.EF;
using FruitStore.DAL.Models;
using FruitStore.DTOS.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Business.Business
{
    public class CustomerBusiness :Repository<Customer>, ICustomerBusiness
    {
        public CustomerBusiness(fruitstoreContext context) : base(context)
        {
           
           
        }
        public async Task<object> Authenticate(LoginRequest loginRequest)
        {
            string hashPassword = MD5Hash(loginRequest.Password);
            var checkResult = await Get(x => x.Phonenumber.Equals(loginRequest.PhoneNumber) && x.Pwd == hashPassword);
            return checkResult;
        }

        public async Task<bool> Register(RegisterRequest registerRequest)
        {
            var customer = await Get(x => x.Phonenumber == registerRequest.Phonenumber,null);
            if (customer.Count>0) {
                return false;
            }
            Customer entity = new Customer()
            {
                Phonenumber = registerRequest.Phonenumber,
                Pwd = MD5Hash(registerRequest.Pwd),
                Addr = registerRequest.Addr
            };
            return await Insert(entity);
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
