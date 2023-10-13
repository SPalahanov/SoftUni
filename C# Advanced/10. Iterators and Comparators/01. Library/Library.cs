using IteratorsAndComparators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new BooksEnumerator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class BooksEnumerator : IEnumerator<Book>
    {
        private List<Book> books;

        private int index = -1;

        public BooksEnumerator(List<Book> books)
        {
            this.books = books;
        }

        public bool MoveNext()
        {
            index++;

            return index < books.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        public Book Current => books[index];


        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }
    }
}