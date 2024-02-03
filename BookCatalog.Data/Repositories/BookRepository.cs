using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookCatalog.Model;

namespace BookCatalog.Data.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly Context _dbContext;

        public BookRepository(
            Context dbContext
            )
        {
            _dbContext = dbContext;
        }

        public int Save(Book book)
        {
            _dbContext.Book.Add(book);
            _dbContext.SaveChanges();
            return book.Id;
        }

        public Book GetById(int bookId)
        {
            return _dbContext.Book.Find(bookId);
        }

        public bool Delete(Book book)
        {
            _dbContext.Book.Remove(book);

            return _dbContext.SaveChanges() == 1;
        }

        public Book Update(Book book)
        {
            _dbContext.Book.Update(book);
            _dbContext.SaveChanges();
            return book;
        }

        public List<Book> GetByPublishedDate(DateTime publishedDate)
        {
            string formattedDate = publishedDate.ToString("MM-dd-yyyy");
            return _dbContext.Book.Where(b => b.PublishDateUtc.ToString("MM-dd-yyyy") == formattedDate).ToList();
        }

        public List<Book> GetAll()
        {
            return _dbContext.Book.ToList();
        }

        public List<Book> GetByName(string bookName)
        {
            return _dbContext.Book.Where(b => b.Title == bookName).ToList();
        }
    }
}
