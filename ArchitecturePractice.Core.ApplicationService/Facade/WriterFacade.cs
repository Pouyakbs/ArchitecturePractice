using ArchitecturePractice.Core.Contracts.Facade;
using ArchitecturePractice.Core.Contracts.UnitofWork;
using ArchitecturePractice.Core.Domain.DTOs;
using ArchitecturePractice.Core.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace ArchitecturePractice.Core.ApplicationService.Facade
{
    public class WriterFacade : IWriterFacade
    {
        private readonly IUnitOfWork unitofWork;
        private readonly IMapper mapper;

        public WriterFacade(IUnitOfWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public int Add(WriterDTO entity)
        {
            Writer WriterDTO = mapper.Map<WriterDTO, Writer>(entity);
            unitofWork.Writer.Add(WriterDTO);
            unitofWork.Save();
            return entity.WriterID;
        }

        public IEnumerable<WriterDTO> GetAll()
        {
            IEnumerable<Writer> Writers = unitofWork.Writer.GetAll();
            IEnumerable<WriterDTO> WritersDTO = mapper.Map<IEnumerable<Writer>, IEnumerable<WriterDTO>>(Writers);
            return WritersDTO;
        }

        public WriterDTO GetById(int id)
        {
            Writer Writer = unitofWork.Writer.GetById(id);
            WriterDTO WriterDTO = mapper.Map<Writer, WriterDTO>(Writer);
            return WriterDTO;
        }

        public void Remove(WriterDTO entity)
        {
            Writer WriterDTO = mapper.Map<WriterDTO, Writer>(entity);
            unitofWork.Writer.Remove(WriterDTO);
            unitofWork.Save();
        }

        public void Update(WriterDTO entity)
        {
            Writer WriterDTO = mapper.Map<WriterDTO, Writer>(entity);
            unitofWork.Writer.Update(WriterDTO);
            unitofWork.Save();
        }
    }
}
