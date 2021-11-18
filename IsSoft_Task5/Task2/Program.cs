using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new("book1", DateTime.Now);
            Book book2 = new("book2", DateTime.Now);
            Book book3 = new("book3", DateTime.Now);
            Book book4 = new("book4", DateTime.Now);

            book1.AddAuthor("Author1");
            book1.AddAuthor("Author2");
            book1.AddAuthor("Author3");
            book1.AddAuthor("Author4");
            book2.AddAuthor("Author1");
            book3.AddAuthor("Author1");
            book4.AddAuthor("Author1");

            Catalog catalog = new();

            catalog["2-266-11156-6"] = book1;
            catalog["2-266-11156-1"] = book2;
            catalog["2-266-11156-2"] = book3;
            catalog["2-266-11156-4"] = book4;

            Console.WriteLine(catalog);
        }
    }
}
