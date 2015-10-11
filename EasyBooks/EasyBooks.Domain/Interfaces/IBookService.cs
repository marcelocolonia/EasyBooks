using System;
using System.Collections.Generic;

namespace EasyBooks.Domain
{
    public interface IBookService
    {
        Book Find(long id);
        IList<Book> Retrieve(Func<Book, bool> filter);
        void InsertBook(Book book);
        void Save(long id, Book book);
        void Delete(long id);
    }
}
