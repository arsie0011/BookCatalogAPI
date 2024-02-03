using AutoMapper;
using BookCatalog.Data.Repositories;
using System;
using System.Collections.Generic;
using dto = BookCatalog.Service.DTO;
using model = BookCatalog.Model;

namespace BookCatalog.Service.Services
{
    public class BookService: IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public BookService(
            IMapper mapper,
            IBookRepository bookRepository
            )
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public dto.Book Save(dto.Book book)
        {
            model.Book bookModel = _mapper.Map<model.Book>(book);

            int bookId  = _bookRepository.Save(bookModel);
            bookModel = _bookRepository.GetById(bookId);

            return _mapper.Map<dto.Book>(bookModel);
        }

        public bool DeleteById(int bookId)
        {
            bool isDeleted = false;
            model.Book bookModel = _bookRepository.GetById(bookId);
            if(bookModel == null)
            {
                return isDeleted;
            }

            isDeleted = _bookRepository.Delete(bookModel);

            return isDeleted;
        }

        public dto.Book UpdateById(int bookId, int categoryId, string title, string description)
        {
            model.Book bookModel = _bookRepository.GetById(bookId);
            if(bookModel != null)
            {
                bookModel.CategoryId = categoryId;
                bookModel.Title = title;
                bookModel.Description = description;
                bookModel = _bookRepository.Update(bookModel);
            }

            return _mapper.Map<dto.Book>(bookModel);
        }

        public List<dto.Book> GetByPublishedDate(DateTime publishedDate)
        {
            List<model.Book> bookModel = _bookRepository.GetByPublishedDate(publishedDate);

            return _mapper.Map<List<dto.Book>>(bookModel);
        }

        public List<dto.Book> GetAll()
        {
            List<model.Book> bookModel = _bookRepository.GetAll();

            return _mapper.Map<List<dto.Book>>(bookModel);
        }

        public List<dto.Book> GetByName(string bookName)
        {
            List<model.Book> bookModel = _bookRepository.GetByName(bookName);

            return _mapper.Map<List<dto.Book>>(bookModel);
        }

        public dto.Book GetById(int bookId)
        {
            model.Book bookModel = _bookRepository.GetById(bookId);

            return _mapper.Map<dto.Book>(bookModel);
        }
    }
}
