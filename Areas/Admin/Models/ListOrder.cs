using Cafe_manager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafe_manager.Areas.Admin.Models
{
    public class ListOrder
    {
        public List<Order> listOrder { get; set; }
        public List<OrderDetail> ListOrderDetail { get; set; }
    }
}