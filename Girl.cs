using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    [Couple(Pair = "Student", Probability = 0.4, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 0.8, ChildType = "SmartGirl")]
    internal class Girl : Human
    {
        public Girl() : base("Girl") { }
        public Girl(string name) : base(name) { }
    }
}
