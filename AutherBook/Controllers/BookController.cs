using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutherBook.Domain;
using AutherBook.Env;
using AutherBook.Repositories;

namespace AutherBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookController(IBookRepository bookRep)
        {
            _bookRep = bookRep;
        }
        public  IBookRepository _bookRep { get; set; }
        [HttpGet]
        //public async Task<List<Book>> getBooks()
        //{
        //    try
        //    {
        //        var books = await _bookRep.getBooks();
        //        if (books == null) { return StatusCode(404); }
        //        else if (books.Count == 0) { return NoContent(); } //test if the array is empty diff from null
        //        return Ok(books);
        //    }
        //    catch (Exception e)
        //    {

        //        return Problem(e.Message);
        //    }
        //}
        //[HttpPost]
        //public async Task<Book> createBook(Book book)
        //{
        //    try
        //    {
        //        if (book == null)
        //        {
        //            return NoContent();
        //        }
        //        var createbook = await _bookRep.createbook(book);
        //        return Created("", createbook);
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(e.Message);
        //    }
        //}
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteBook(int id)
        {
            try
            {
                await _bookRep.deleteBook(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updateBook(int id, Book book)
        {
            try
            {
                if (id != book.Id)
                {
                    return BadRequest();
                }
                var UpdateBookInfomation = await _bookRep.updateBook(id, book);
                return Ok(UpdateBookInfomation);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

    }
}
