using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingADO.Controllers
{
    public class BookController : Controller
    {
        BookDAL bookdal;
        private readonly IConfiguration configuration;
        public BookController(IConfiguration configuration)
        {
            this.configuration = configuration;
            bookdal = new BookDAL(configuration);

        }
        // GET: EmployeeController
        // GET: BoolController
        public ActionResult Index()
        {
            var model = bookdal.GetBook();
            return View(model);

        }

        // GET: BoolController/Details/5
        public ActionResult Details(int id)
        {

            var book = bookdal.GetBookById(id);
            return View(book);
        }

        // GET: BoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {

            try
            {
                int result = bookdal.AddBook(book);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }

        }

        // GET: BoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookdal.GetBookById(id);
            return View(book);

        }

        // POST: BoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int result = bookdal.EditBook(book);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: BoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookdal.GetBookById(id);
            return View(book);
        }

        // POST: BoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = bookdal.DeleteBook(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
