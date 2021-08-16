using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutherBook.Domain
{
    public class Super
    {
        public int Id { get; set; } // PK for alt tables 
        public DateTime deletedAt { get; set; }
        public DateTime createAt { get; set; }
        public DateTime lastupdatedAt { get; set; }
    }
}
