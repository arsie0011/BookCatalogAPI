using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dto = BookCatalog.Service.DTO;

namespace BookCatalog.Service.Services
{
    public interface IBookService
    {
        dto.Book Save(dto.Book book);
        bool DeleteById(int bookId);
        dto.Book UpdateById(int bookId, int categoryId, string title, string description);
        List<dto.Book> GetByPublishedDate(DateTime pusblishedDate);
        List<dto.Book> GetAll();
        List<dto.Book> GetByName(string bookName);
        dto.Book GetById(int bookId);
    }
}
