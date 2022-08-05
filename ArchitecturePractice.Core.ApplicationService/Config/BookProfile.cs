using ArchitecturePractice.Core.Domain.DTOs;
using ArchitecturePractice.Core.Domain.Entities;
using AutoMapper;

namespace ArchitecturePractice.Core.ApplicationService.Config
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
        }
    }
}
