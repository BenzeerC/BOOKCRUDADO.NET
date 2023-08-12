using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKCRUDADO.NET.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Book_Name { get; set; }

        public string Author { get; set;}

        public int Price { get; set;}
    }
}
