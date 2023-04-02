using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Entity.Modals
{
    public class Carrier
    {
        [Key]
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public int? CarrierConfigurationId { get; set; }

        public List<Order> Orders { get; set; }
        public List<CarrierConfiguration> CarrierConfigurations { get; set; }
    }
}
