using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCatalog.Service.DTO;
using BookCatalog.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookservice;

        public BookController(
            IBookService bookService
            )
        {
            _bookservice = bookService;
        }

        // GET api/values
        [HttpPost]
        [Route("Save")]
        public ActionResult<Book> Save(Book book)
        {
            var savedBook = _bookservice.Save(book);
            if(savedBook == null)
            {
                return NotFound();
            }

            return Ok(savedBook);
        }

        [HttpPost]
        [Route("DeleteById")]
        public ActionResult<bool> DeleteById(int bookId)
        {
            bool isDeleted = _bookservice.DeleteById(bookId);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok("Book Deleted!");
        }

        [HttpPost]
        [Route("UpdateById")]
        public ActionResult<Book> UpdateById(int bookId, int categoryId, string title, string description)
        {
            var updatedBook  = _bookservice.UpdateById(bookId, categoryId, title, description);
            if (updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        [HttpGet]
        [Route("GetByPublishedDate")]
        public ActionResult<List<Book>> GetByPublishedDate(DateTime publishedDate)
        {
            var book = _bookservice.GetByPublishedDate(publishedDate);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Book>> GetAll()
        {
            var book = _bookservice.GetAll();
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet]
        [Route("GetByName")]
        public ActionResult<List<Book>> GetByName(string bookName)
        {
            var book = _bookservice.GetByName(bookName);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<Book> GetById(int bookId)
        {
            var book = _bookservice.GetById(bookId);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
