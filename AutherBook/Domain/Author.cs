using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutherBook.Domain
{
    public class Author : Super
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Book { get; set; } // firstname last name here
    }
}
