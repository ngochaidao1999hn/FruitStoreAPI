using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.DTOS.OrderDTOs
{
    public class OrderDetail
    {
        public int? CartId { get; set; }
        public int? ProId { get; set; }
        public int? Quantity { get; set; }
        public bool? Ispaid { get; set; }
        public double? Pric { get; set; }
        public int? OrderStatus { get; set; }
    }
}
