using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.DTOS.OrderDTOs
{
    public class CreateOrderDto
    {
        public int? CusId { get; set; }
        public IEnumerable<OrderDetail> Details { get; set; }
    }
}
