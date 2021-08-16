using AutherBook.Domain;
using AutherBook.Env;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutherBook.Repositories
{
    /// <summary>
    /// define some methods that can respond to my controller
    /// crod = select / update / insert / delete
    /// </summary>
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Databasecontext _context;
        public AuthorRepository(Databasecontext context)
        {
            _context = context;
        }
        
        public async Task<Author> create(Author author)
        {
            // this create an Author
            author.createAt = DateTime.UtcNow;
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
            //throw new NotImplementedException();
        }

        public async Task<ActionResult> delete(int id)
        {
            Author author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync(); // if( >0) its done
            }
            return author == null ? new NotFoundResult() : new OkResult();
        }

        public async Task<ActionResult> update(int it, Author author)
        {
            EntityState entity = _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<List<Author>> getAuthors()
        {
            List<Author> authors = await _context.Authors.ToListAsync(); // get all authors.
            return authors;
        }

        public async Task<Author> getAuthor(int id)
        {
            Author author = await _context.Authors.FindAsync(id);
            return author;
        }
        public async Task<Author> getAuthor2(int id) // test
        {
            string name = "bo";
            Author author = await _context.Authors.Where((a) => a.Id ==id).FirstOrDefaultAsync();
            List<Author> obj = await _context.Authors.Where(a => a.Id < id).ToListAsync();
            // var obj = await _context.Authors.Where(a => a.Id < id).ToListAsync();

            List<Author> obj2 = await _context.Authors.Where(find => find.FirstName == name).ToListAsync();
            return author;
        }

        public async Task<Author> getAuthorsBooks()
        {
            throw new NotImplementedException();
        }
    }
}
