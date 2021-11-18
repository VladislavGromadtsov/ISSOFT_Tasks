using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    public class Catalog : Collection<(string isbn, Book book)>
    {
        public Book this[string isbn]
        {
            get
            {
                CheckFormat(ref isbn);

                var book = Items.FirstOrDefault(el => el.isbn == isbn).book;
                return book ?? throw new KeyNotFoundException("Check your key");
            }
            set
            {
                CheckFormat(ref isbn);

                var index = GetIndex(isbn);
                if (index == -1)
                {
                    Add((isbn, value));
                }
                else
                {
                    SetItem(index, (isbn, value));
                }
            }
        }

        public void RemoveItem(string isbn)
        {
            CheckFormat(ref isbn);

            var index = GetIndex(isbn);
            if (index != -1)
            {
                RemoveItem(index);
            }
        }

        protected override void SetItem(int index, (string isbn, Book book) item)
        {
            CheckFormat(ref item.isbn);

            if (item.book is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            base.SetItem(index, item);
        }

        protected override void InsertItem(int index, (string isbn, Book book) item)
        {
            CheckFormat(ref item.isbn);
            if (Items.Any(el => el.isbn == item.isbn))
            {
                throw new ArgumentException("Book with such isbn is already taken!");
            }

            if (item.book == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            base.InsertItem(index, item);
        }

        public override string ToString()
        {
            string str = "Books:\n";
            foreach (var (isbn, book) in this)
            {
                str += $"ISBN: {isbn}\n{book}\n";
            }

            return str;
        }

        private void CheckFormat(ref string isbn)
        {
            Regex regex = new Regex("[0-9]{1}-[0-9]{3}-[0-9]{5}-[0-9, 'x']{1}");
            Regex regex2 = new Regex("[0-9, x]{10}");
            if (regex.IsMatch(isbn) || regex2.IsMatch(isbn))
            {
                isbn = isbn.Replace("-", "");
            }
            else
            {
                throw new FormatException("Check ISBN format");
            }
        }

        private int GetIndex(string isbn)
        {
            return Items.Where(el => el.isbn == isbn).Select(e => Items.IndexOf(e)).DefaultIfEmpty(-1).FirstOrDefault();
        }
    }
}