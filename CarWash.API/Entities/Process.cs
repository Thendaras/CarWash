using System.Collections.Generic;

namespace CarWash.Entities
{
    public class Process : BaseEntity
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public int Duration { get; set; }
        public double Cost { get; set; }
        public List<WashType> Washes { get; set; }
    }
}