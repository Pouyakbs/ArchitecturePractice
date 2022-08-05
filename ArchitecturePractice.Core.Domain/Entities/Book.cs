using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturePractice.Core.Domain.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public DateTime PubDate { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int WriterID { get; set; }
        public Writer Writer { get; set; }
    }
}
