using AutherBook.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutherBook.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> getBooks();
        Task<Book> createbook(Book book);
        Task<ActionResult> deleteBook(int id);
        Task<ActionResult> updateBook(int id, Book book);
    }
}
