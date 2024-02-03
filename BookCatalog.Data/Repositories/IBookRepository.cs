using BookCatalog.Model;
using System;
using System.Collections.Generic;

namespace BookCatalog.Data.Repositories
{
    public interface IBookRepository
    {
        int Save(Book book);
        Book GetById(int bookId);
        bool Delete(Book book);
        Book Update(Book book);
        List<Book> GetByPublishedDate(DateTime publishedDate);
        List<Book> GetAll();
        List<Book> GetByName(string bookName);
    }
}
