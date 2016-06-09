using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class AddBooksController : Controller
    
    {  //
        // GET: /AddBooks/
        /// <summary>
        /// КОнтроллер манипуляции с книгами
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBooks()
        {
            return View();
        }

        //Добавление книги
    [HttpPost]
        public ActionResult AddBooks(Book book)
        { 
            AddBooksModel.AddBookToDb(book);
            return RedirectToAction("index","Home");
        }

        //Удаление книги
    public ActionResult RemBooks(int id)
    {
        AddBooksModel.RemoveBookFromBd(id);
        return RedirectToAction("index", "Home");
    }

    }
}
