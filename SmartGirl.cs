using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    [Couple(Pair = "Student", Probability = 1, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 0.8, ChildType = "Book")]
    internal class SmartGirl : Human
    {
        public SmartGirl() : base("Smart Girl") { }
        public SmartGirl(string name) : base(name) { }
    }
}
