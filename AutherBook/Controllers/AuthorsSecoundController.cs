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
    // Endpoint
    public class AuthorsSecoundController : ControllerBase
    {
        public AuthorsSecoundController(IAuthorRepository authorRep)
        {
            _authorRep = authorRep;
        }
        public IAuthorRepository _authorRep { get; set; }
        [HttpPost]
        public async Task<ActionResult<Author>> createAuthor(Author author)
        {
            // impl try catch in here
            try
            {
                //1 test if created or not created
                if (author == null)
                {
                    return NoContent();
                }
                var createAuthor = await _authorRep.create(author);
                return Created("", createAuthor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        // methods that calls to the database
        [HttpGet]
        public async Task<IActionResult> getAuthors()
        {
            try
            {
                var authors = await _authorRep.getAuthors();
                if(authors == null ) { return StatusCode(404);  }
                else if (authors.Count == 0) { return NoContent(); } //test if the array is empty diff from null
                return Ok(authors);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            try
            {
                Author author = await _authorRep.getAuthor(id);
                return author == null ? NotFound() : Ok(author);
                //if (author == null)
                //{
                //    return NotFound();
                //}
                //return Ok(author);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        //[HttpGet("{authorId}")]
        //public async Task<ActionResult<Author>> getAuthorsBooks()
        //{
        //    try
        //    {
        //        Author author = await _authorRep.getAuthorsBooks();
        //        return author == null ? NotFound() : Ok(author);
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(e.Message);
        //    }
        //}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> delete(int id)
        {
            await _authorRep.delete(id);
            return NoContent();
        }
        //public string get() { return "iam an endpoint"; }
        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, Author author)
        {
            try
            {
                if (id != author.Id)
                {
                    return BadRequest();
                }
                var UpdateInfo = await _authorRep.update(id, author);
                return Ok(UpdateInfo);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
