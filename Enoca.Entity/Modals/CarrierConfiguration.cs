﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Entity.Modals
{
    public class CarrierConfiguration
    {
        [Key]
        public int CarrierConfigurationId { get; set; }
        public int? CarrierId { get; set; }
        public Carrier Carrier { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }
    }
}
