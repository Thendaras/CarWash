using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Entities
{
    public class Facility : BaseEntity
    {
        public Facility()
        {
            Orders = new List<Order>();
        }

        public string Location { get; set; }
        public List<Order> Orders { get; set; }
    }
}
