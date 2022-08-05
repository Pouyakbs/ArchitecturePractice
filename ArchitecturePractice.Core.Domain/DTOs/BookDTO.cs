using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturePractice.Core.Domain.DTOs
{
    public class BookDTO
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public DateTime PubDate { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int WriterId { get; set; }
    }
}
