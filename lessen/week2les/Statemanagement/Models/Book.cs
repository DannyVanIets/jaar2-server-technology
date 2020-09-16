using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statemanagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }

        public Book(int id, string isbn, string title)
        {
            Id = id;
            ISBN = isbn;
            Title = title;
        }

        public override string ToString()
        {
            return $"{Id} - {Title} - ({ISBN})";
        }
    }
}
