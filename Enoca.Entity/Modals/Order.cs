using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Entity.Modals
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal OrderCarrierCost { get; set; }
    }
}
