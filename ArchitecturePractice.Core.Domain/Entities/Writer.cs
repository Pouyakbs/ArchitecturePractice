using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturePractice.Core.Domain.Entities
{
    public class Writer
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
        public List<Book> Books { get; set; }
    }
}
