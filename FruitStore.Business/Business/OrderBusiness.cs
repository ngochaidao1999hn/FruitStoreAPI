using FruitStore.Business.Interfaces;
using FruitStore.DAL.EF;
using FruitStore.DAL.Models;
using FruitStore.DTOS.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Business.Business
{

    public class OrderBusiness :Repository<Cart> ,IOrderBusiness
    {             
        private readonly IRepository<CartDetail> _cartdetailRepo;
        private readonly IRepository<Customer> _customerRepo;
        public OrderBusiness(fruitstoreContext context,
            IRepository<CartDetail> cartdetailRepo,
            IRepository<Customer> customerRepo):base(context)
        {
            _context = context;
            _cartdetailRepo = cartdetailRepo;
            _customerRepo = customerRepo;
        }
        public async Task<bool> CreateOrder(CreateOrderDto createRequest)
        {
            var status = false;
            var order = new Cart()
            {
                CusId = createRequest.CusId,
                create_date = DateTime.Now
            };
            status = await Insert(order);
            if (!status)
            {
                return false;
            }           
            foreach (var item in createRequest.Details) {
                var orderDetail = new CartDetail()
                {
                    CartId = order.Id,
                    ProId = item.ProId,
                    Quantity = item.Quantity,
                    Ispaid = item.Ispaid,
                    Pric = item.Pric,
                    OrderStatus = item.OrderStatus
                };
                status = await _cartdetailRepo.Insert(orderDetail);
                if (!status) {
                    break;
                }
            }
            if (!status)
            {
                return false;
            }
            return true;

        }

        public async Task<List<OrderGettingDto>> GetByCustomerId(int customerID)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            var orders = await Get(x => x.CusId == customerID);
            var details = await _cartdetailRepo.GetAll();
            foreach (var item in details) {
                orderDetails.Add(new OrderDetail()
                {
                    CartId = item.CartId,
                    ProId = item.ProId,
                    Pric = item.Pric,
                    Quantity = item.Quantity,
                    OrderStatus = item.OrderStatus,
                    Ispaid = item.Ispaid
                });
            }
            var ordermappeds = from order in orders
                               select(
                               new OrderGettingDto()
            {
                CusId = order.CusId,
                Create_Date = order.create_date,
                Details = orderDetails.Where(x=>x.CartId == order.Id)
            });
            return ordermappeds.ToList();
        }

        public async Task<CreateOrderDto> GetOrderById(int CartID)
        {
            var order = await GetByID(CartID);
            var listDetail = await _cartdetailRepo.Get(x => x.CartId == order.Id);

            var listDetailMapped = listDetail.Select(x => new OrderDetail()
            {
                ProId = x.ProId,
                Quantity = x.Quantity,
                Ispaid = x.Ispaid,
                Pric = x.Pric,
                OrderStatus = x.OrderStatus
            });           
            var orderMapped = new CreateOrderDto()
            {
                CusId = order.CusId,
                Details = listDetailMapped
            };
            return orderMapped;
        }
    }
}
