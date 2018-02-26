using System.Collections.Generic;

namespace CarWash.API.Entities
{
    public class WashType : BaseEntity
    {
        public WashType()
        {
            Processes = new List<Process>();
        }

        public string Name { get; set; }
        public List<Process> Processes { get; set; }

        public double CalculateCost()
        {
            double cost = 0.00;
            foreach (Process p in Processes)
            {
                cost += p.Cost;
            }

            return cost;
        }
    }
}