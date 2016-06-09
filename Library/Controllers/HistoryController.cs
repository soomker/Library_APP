using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using Library.Controllers;
using Library.Helpers;

namespace Library.Controllers
{
    public class HistoryController : Controller
    {
        //
        // GET: /History/
        /// <summary>
        /// Контроллер истории
        /// </summary>
        /// <param name="user"></param>
        /// <param name="bookId"></param>
        /// <param name="bookName"></param>
        /// <returns></returns>
        
        //Взяли книгу, отправили мэил
        public ActionResult History(string user, int bookId, string bookName)
        {
            LibraryModel.TakeBook(user, bookId);
           EmailHelper emailConn = new EmailHelper();
            emailConn.SendMail(user, bookName);
            return RedirectToAction("index", "Home");
        }

        //Получить историю книги
        public ActionResult GetHistory(int bookId, string bookName)
        {
            BookHistoryModel bookHis = new BookHistoryModel();
            bookHis.ShowBookHistory(bookId, bookName);
            return View("History", bookHis);
        }

    }
}
