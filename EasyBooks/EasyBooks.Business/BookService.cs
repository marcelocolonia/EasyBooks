using EasyBooks.Domain;
using System.Collections.Generic;
using System;
using System.Linq;

namespace EasyBooks.Business
{
    public class BookService : IBookService
    {
        private IGenericRepository<Book> _repository = IoC.Resolve<IGenericRepository<Book>>();

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Book Find(long id)
        {
            return _repository.Find(id);
        }

        public void InsertBook(Book book)
        {
            _repository.Create(book);
        }

        public IList<Book> Retrieve(Func<Book, bool> filter)
        {
            return _repository.GetAll(filter).OrderBy(x => x.Title).ToList();
        }

        public void Save(long id, Book book)
        {
            _repository.Save(id, book);
        }
    }
}
