using ArchitecturePractice.Core.Contracts.Repository;
using ArchitecturePractice.Core.Domain.Entities;
using ArchitecturePractice.Infrastructure.Data.Common;
using ArchitecturePractice.Infrastructure.EF;

namespace ArchitecturePractice.Infrastructure.Data
{
    public class WriterRepository : GenericRepository<Writer>, IWriterRepository
    {
        public WriterRepository(DemoContext Context) : base(Context)
        {
        }
    }
}
