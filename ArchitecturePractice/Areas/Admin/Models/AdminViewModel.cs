using ArchitecturePractice.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitecturePractice.Areas.Admin.Models
{
    public class AdminViewModel
    {
        public IEnumerable<BookDTO> Books { get; set; }
        public IEnumerable<WriterDTO> Writers { get; set; }
        public BookDTO Book { get; set; }
        public WriterDTO Writer { get; set; }

    }
}
