using AutherBook.Controllers;
using AutherBook.Domain;
using AutherBook.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthorBook.Test
{
    /// <summary>
    /// Methods !!
    /// Test getAuthors
    /// </summary>
    public class AuthorRepositoriesTest
    {
        // reuse data information test in "GetAll_HTTPRespones202_WhenDataExists()"
        Mock<IAuthorRepository> dataSource = new Mock<IAuthorRepository>(); // creating a Mockup of the data
        AuthorsSecoundController ClassThatIsTested;
        List<Author> authorList;
        public AuthorRepositoriesTest()
        {
            ClassThatIsTested = new AuthorsSecoundController(dataSource.Object);
        }

        [Fact]
        public async void GetAll_HTTPRespones200_WhenDataExists()
        {
            // the tripled A
            // arrange - Opsætning => Variable init
            // objController and mock data
            var dataSource = new Mock<IAuthorRepository>(); // creating a Mockup of the data
            List<Author> authorList = new List<Author>();
            authorList.Add(new Author());
            authorList.Add(new Author());
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);
            // act - handling => prøve mit data af
            AuthorsSecoundController ClassThatIsTested = new AuthorsSecoundController(dataSource.Object);
            var result = await ClassThatIsTested.getAuthors();
            // assert - Verificer om jeg har gjort det godt nok
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task getAll_shouldReturn204_whenDataExists()
        {
            // the tripple A's
            // arrange
            var dataSource = new Mock<IAuthorRepository>();
            List<Author> authorList = new List<Author>();
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);
            // act - 
            AuthorsSecoundController ClassThatIsTested = new AuthorsSecoundController(dataSource.Object);
            var result = await ClassThatIsTested.getAuthors();
            // assert - checks if it did well
            var StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, StatusCodeResult.StatusCode);
        }
        [Fact]
        public async Task getAll_shouldReturn404_whenAuthorDoesNotExists()
        {
            // arrange
            var dataSource = new Mock<IAuthorRepository>();
            List<Author> authorList = null;
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);
            // act
            var classThatIsTested = new AuthorsSecoundController(dataSource.Object);
            var result = await classThatIsTested.getAuthors();
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task GetAll_HTTPRespones202_WhenDataExists_reuseData()
        {
            // the tripled A
            // arrange
            authorList = new List<Author>();
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);
            // act
            var result = await ClassThatIsTested.getAuthors();
            // assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task create_shouldReturn201_whenCreate()
        {
            
        }
        [Fact]
        public async Task create_shouldReturn400_BadRequest()
        {

        }
    }

}
