using EasyBooks.Domain;
using System.Web.Mvc;

namespace EasyBooks.Web.Controllers.Book
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var service = IoC.Resolve<IBookService>();

            var result = service.Retrieve(x => x != null);

            return View(result);
        }

        public ActionResult Edit(long id)
        {
            if (id != 0)
            {
                var service = IoC.Resolve<IBookService>();

                var book = service.Find(id);

                return View(book);
            }
            else
                return View();
        }

        public ActionResult Delete(long id)
        {
            var service = IoC.Resolve<IBookService>();

            service.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(EasyBooks.Domain.Book book)
        {
            if (ModelState.IsValid)
            {
                var service = IoC.Resolve<IBookService>();

                if (book.ID != 0)
                    service.Save(book.ID, book);
                else
                    service.InsertBook(book);

                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
    }
}