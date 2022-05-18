using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class Book : IHasName
    {
        public string Name 
        { 
            get; 
        }

        public Book()
        {
            Name = "New book";
        }

        public Book(string name)
        {
            Name = name;
        }
       
    }
}
