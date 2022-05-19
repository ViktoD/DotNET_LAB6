using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    [Couple(Pair = "Girl", Probability = 0.3, ChildType = "Girl")]
    [Couple(Pair = "PrettyGirl", Probability = 0.1, ChildType = "PrettyGirl")]
    [Couple(Pair = "SmartGirl", Probability = 0.7, ChildType = "Girl")]
    internal class Student : Human
    {
        public Student() : base("Student","Boy") { }
        public Student(string name, string lastname) : base(name, lastname) { }
    }
}
