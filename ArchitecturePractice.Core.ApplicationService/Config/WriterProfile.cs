using ArchitecturePractice.Core.Domain.DTOs;
using ArchitecturePractice.Core.Domain.Entities;
using AutoMapper;

namespace ArchitecturePractice.Core.ApplicationService.Config
{
    public class WriterProfile : Profile
    {
        public WriterProfile()
        {
            CreateMap<Writer, WriterDTO>();
            CreateMap<WriterDTO, Writer>();
        }
    }
}
