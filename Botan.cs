using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    [Couple(Pair = "Girl", Probability = 0.9, ChildType = "SmartGirl")]
    [Couple(Pair = "PrettyGirl", Probability = 0.5, ChildType = "PrettyGirl")]
    [Couple(Pair = "SmartGirl", Probability = 0.8, ChildType = "Book")]
    internal class Botan : Human
    {
        public Botan() : base("Botan","Boy") { }
        public Botan(string name, string lastname) : base(name, lastname) { }
    }
}
