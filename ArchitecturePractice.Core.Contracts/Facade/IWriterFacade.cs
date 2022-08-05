using ArchitecturePractice.Core.Domain.DTOs;
using System.Collections.Generic;

namespace ArchitecturePractice.Core.Contracts.Facade
{
    public interface IWriterFacade
    {
        WriterDTO GetById(int id);
        IEnumerable<WriterDTO> GetAll();
        int Add(WriterDTO entity);
        void Remove(WriterDTO entity);
        void Update(WriterDTO entity);
    }
}
