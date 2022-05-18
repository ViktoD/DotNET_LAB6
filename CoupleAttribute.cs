using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    internal class CoupleAttribute : Attribute
    {
        public string Pair 
        { 
            get; 
            set; 
        }
        public double Probability 
        { 
            get; 
            set; 
        }
        public string ChildType 
        { 
            get; 
            set; 
        }

    }
}
