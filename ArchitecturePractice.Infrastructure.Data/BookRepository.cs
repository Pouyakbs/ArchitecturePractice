using ArchitecturePractice.Core.Contracts.Repository;
using ArchitecturePractice.Core.Domain.Entities;
using ArchitecturePractice.Infrastructure.Data.Common;
using ArchitecturePractice.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturePractice.Infrastructure.Data
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DemoContext Context) : base(Context)
        {
        }
    }
}
