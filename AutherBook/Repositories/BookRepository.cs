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
    public class BookRepository : IBookRepository
    {
        private readonly Databasecontext _context;
        public BookRepository(Databasecontext context)
        {
            _context = context;
        }
        public async Task<List<Book>> getBooks()
        {
            List<Book> books = await _context.books.ToListAsync();
            // can now return it....
            throw new NotImplementedException();
        }

        public async Task<Book> createbook(Book book)
        {
            book.createAt = DateTime.UtcNow;
            _context.books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<ActionResult> deleteBook(int id)
        {
            Book book = await _context.books.FindAsync(id);
            if (book != null)
            {
                _context.books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return book == null ? new NotFoundResult() : new OkResult();
        }

        public Task<ActionResult> updateBook(int id, Book book)
        {
            throw new NotImplementedException();
        }

        // ---------------------------------------

    }
}
