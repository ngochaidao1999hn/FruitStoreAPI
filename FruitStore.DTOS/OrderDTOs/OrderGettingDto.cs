using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.DTOS.OrderDTOs
{
    public class OrderGettingDto
    {
        public int? CusId { get; set; }
        public DateTime Create_Date{ get; set; }
        public IEnumerable<OrderDetail> Details { get; set; }
    }
}
