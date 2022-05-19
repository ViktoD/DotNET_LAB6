using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class MatchGender : Exception
    {
        public MatchGender(string message) : base(message) { }
    }
}
