using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Order
    {
        public int Oid { get; set; }
        public int? Custid { get; set; }
        public int? Pid { get; set; }
        public int? Qty { get; set; }
        public DateTime? DateOfPurchase { get; set; }

        public virtual Customer? Cust { get; set; }
        public virtual Product? PidNavigation { get; set; }
    }
}
