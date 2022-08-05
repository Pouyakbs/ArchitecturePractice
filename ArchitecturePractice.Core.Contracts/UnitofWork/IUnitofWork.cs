using ArchitecturePractice.Core.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturePractice.Core.Contracts.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IBookRepository Book { get; }
        public IWriterRepository Writer { get; }
        int Save();
    }
}
