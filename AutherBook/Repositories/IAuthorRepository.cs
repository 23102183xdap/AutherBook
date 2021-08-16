using AutherBook.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutherBook.Repositories
{
    /// <summary>
    /// Test program can't work with methoder, men but it can work with interface = IAuthorRepository
    /// </summary>
    public interface IAuthorRepository
    {
        Task<Author> create(Author author);
        Task<ActionResult> delete(int id);
        Task<ActionResult> update(int id, Author author);
        Task<List<Author>> getAuthors();
        //Task<List<Author>> getAuthors(int start, int limit);
        Task<Author> getAuthor(int id);


    }
}
