using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WookieBooks.Core.IRepository;
using WookieBooks.Models;
using WookieBooksApi.Controllers;
using Xunit;

namespace booksApiTest
{
    public class bookControllerTest
    {
        private readonly BooksController _controller;
        private readonly IBookService _service;

        public bookControllerTest()
        {
            _service = new BookServiceFake();
            _controller = new BooksController(_service);
        }


        [Fact]
        public async void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult =  _controller.Getbooks();

            // Assert
            var items = Assert.IsType<List<Book>>(okResult.Result.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_UnknownIDPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetBook(7);

            // Assert
            Assert.IsType<FileNotFoundException>(notFoundResult.Exception.InnerException);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            int testId = 1;

            // Act
            var okResult = _controller.GetBook(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result.Result as OkObjectResult);
        }





        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Book testItem = new Book()
            {
                Title = "Guinness",
                Author = "Mr.X",
                Price = 12.00
            };

            // Act
            var createdResponse = _controller.PostBook(testItem);

            // Assert
            Assert.IsType<OkObjectResult>(createdResponse.Result.Result);
        }

    


    }
}
