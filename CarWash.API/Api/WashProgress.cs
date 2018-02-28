using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Api
{
    public class WashProgress
    {
        public int CurrentProgress { get; set; }
        public int MaxProgress { get; set; }
        public string Name { get; set; }
    }
}

