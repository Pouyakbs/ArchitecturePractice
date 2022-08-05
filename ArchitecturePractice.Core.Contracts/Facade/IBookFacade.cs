using ArchitecturePractice.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturePractice.Core.Contracts.Facade
{
    public interface IBookFacade
    {
        BookDTO GetById(int id);
        IEnumerable<BookDTO> GetAll();
        int Add(BookDTO entity);
        void Remove(BookDTO entity);
        void Update(BookDTO entity);
    }
}
