using AutherBook.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutherBook.Env
{
    public class Databasecontext : DbContext
    {
        public Databasecontext(DbContextOptions<Databasecontext> options) : base(options) { }
        public Databasecontext()
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> books { get; set; }
    }
}
