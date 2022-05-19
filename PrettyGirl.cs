using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    [Couple(Pair = "Student", Probability = 0.8, ChildType = "PrettyGirl")]
    [Couple(Pair = "Botan", Probability = 0.6, ChildType = "PrettyGirl")]
    internal class PrettyGirl : Human
    {
        public PrettyGirl() : base("Pretty","Girl") { }
        public PrettyGirl(string name, string lastname) : base(name,lastname) { }
    }
}
