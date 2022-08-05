using ArchitecturePractice.Core.Contracts.Facade;
using ArchitecturePractice.Core.Contracts.UnitofWork;
using ArchitecturePractice.Core.Domain.DTOs;
using ArchitecturePractice.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturePractice.Core.ApplicationService.Facade
{
    public class BookFacade : IBookFacade
    {
        private readonly IUnitOfWork unitofWork;
        private readonly IMapper mapper;

        public BookFacade(IUnitOfWork unitofWork , IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public int Add(BookDTO entity)
        {
            Book bookDTO = mapper.Map<BookDTO, Book>(entity);
            unitofWork.Book.Add(bookDTO);
            unitofWork.Save();
            return bookDTO.BookID;
        }

        public IEnumerable<BookDTO> GetAll()
        {
            IEnumerable<Book> books = unitofWork.Book.GetAll();
            IEnumerable<BookDTO> booksDTO = mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);
            return booksDTO;
        }

        public BookDTO GetById(int id)
        {
            Book book = unitofWork.Book.GetById(id);
            BookDTO bookDTO = mapper.Map<Book ,BookDTO>(book);
            return bookDTO;
        }

        public void Remove(BookDTO entity)
        {
            Book bookDTO = mapper.Map<BookDTO, Book>(entity);
            unitofWork.Book.Remove(bookDTO);
            unitofWork.Save();
        }

        public void Update(BookDTO entity)
        {
            Book bookDTO = mapper.Map<BookDTO, Book>(entity);
            unitofWork.Book.Update(bookDTO);
            unitofWork.Save();
        }
    }
}
