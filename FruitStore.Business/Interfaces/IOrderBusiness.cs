using FruitStore.DAL.Models;
using FruitStore.DTOS.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Business.Interfaces
{
    public interface IOrderBusiness:IRepository<Cart>
    {
        public Task<bool> CreateOrder(CreateOrderDto createRequest);
        public Task<CreateOrderDto> GetOrderById(int CartID);
        public Task<List<OrderGettingDto>> GetByCustomerId(int customerID);
    }
}
