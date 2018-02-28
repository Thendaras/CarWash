using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Entities
{
    public class Order : BaseEntity
    {
        public double Price { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Completed { get; set; }
        public DateTime? Aborted { get; set; }
        public int WashTypeID { get; set; }
        [ForeignKey(nameof(WashTypeID))]
        public virtual WashType WashType { get; set; }
        public int FacilityID { get; set; }
        [ForeignKey(nameof(FacilityID))]
        public Facility Facility { get; set; }
    }
}
