using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using PagedList;
using PagedList.Mvc;
using System.Data;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        /// <summary>
        /// Основной контроллер
        /// </summary>
      public  List<DataRow> rows = new List<DataRow>();

      public List<DataRow> sortRows = new List<DataRow>();
      
         
      public static List<DataRow> sortRowsByUser = new List<DataRow>();
        public HomeController ()
        {
            LibraryModel libModel = new LibraryModel();
            foreach (DataRow row in libModel.GetDataTableFromDb().Rows)
            {
                rows.Add(row);
            }
            
        }

        //Заполняем список книг взятых юзером
        public  void FillBooksByUserList(string user)
        {
            LibraryModel libModel = new LibraryModel();
            sortRowsByUser.Clear();
            foreach (DataRow row in libModel.GetBooksTakenByUser(user).Rows)
            {
                sortRowsByUser.Add(row);
            }
        }
        //Отображаем список взятых юзером книг
        public ActionResult SortByUser(int? page)
        {
                     
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(sortRowsByUser.ToPagedList(pageNumber, pageSize));
        }

        //Показать только доступные книги
        public ActionResult Sort(int? page)
        {
            LibraryModel libModel = new LibraryModel();
            foreach (DataRow row in libModel.GetAvaibleBooks().Rows)
            {
                sortRows.Add(row);
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(sortRows.ToPagedList(pageNumber, pageSize));
        }

        //Гдавная страница
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(rows.ToPagedList(pageNumber, pageSize));
        }

    }
}
