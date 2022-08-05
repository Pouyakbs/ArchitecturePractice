using ArchitecturePractice.Core.Contracts.Repository;
using ArchitecturePractice.Core.Contracts.UnitofWork;
using ArchitecturePractice.Infrastructure.Data;
using ArchitecturePractice.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturePractice.Core.ApplicationService.UnitofWork
{
    public class UnitofWork : IUnitOfWork
    {
        private DemoContext context;

        public UnitofWork(DemoContext context)
        {
            this.context = context;
            Book = new BookRepository(this.context);
            Writer = new WriterRepository(this.context);
        }
        public IBookRepository Book { get;private set; }

        public IWriterRepository Writer { get;private set; }

        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
