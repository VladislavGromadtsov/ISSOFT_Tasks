using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Book
    {
        public string Title { get; }
        public DateTime? Date { get; }
        public SortedSet<string> Authors { get; }

        public Book(string title, DateTime? date)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title should be not null or empty");
            }

            Title = title;
            Date = date;
            Authors = new SortedSet<string>();
        }

        public void AddAuthor(string author)
        {
            if(string.IsNullOrEmpty(author))
            {
                throw new ArgumentException("Author value should be not null or empty");
            }

            Authors.Add(author);
        }

        public override string ToString()
        {
            var str = $"Title: {Title}\tDate: {Date}\tAuthors: ";
            foreach (var author in Authors)
            {
                str += author + " ";
            }

            return str;
        }

    }
}