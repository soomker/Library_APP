using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Library.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
   /// <summary>
   /// Модель для манипуляции книгами в библиотеке
   /// </summary>
    public class AddBooksModel
    {
       [Required(ErrorMessage="PLEASE ENTER BOOK NAME!!!")]
        public virtual string BookName { get; set; }
       [Required(ErrorMessage = "PLEASE ENTER AUTORS of BOOK!!!")]
        public virtual string Autors { get; set; }
        [Required(ErrorMessage = "PLEASE ENTER STATUS (TRUE, FALSE)!!!")]
        public virtual string IsAvaible { get; set; }

       
        //Добавить книгу
        public static void AddBookToDb(Book book)
        { 
         MySqlConnection conn = LibraryModel.ConnectToDb();
         MySqlCommand comm = new MySqlCommand(String.Format(@"INSERT INTO `book`(`Book`, `IsAvailable`) VALUES ('{0}','{1}')",book.BookName, book.IsAvaible),conn);
            conn.Open();
            comm.ExecuteNonQuery();
            string [] arr = book.BookName.Split(',');
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    comm = new MySqlCommand(String.Format(@"INSERT INTO `autors`(`BookId`) SELECT book.id FROM `book` WHERE book.Book = '{0}'", arr[i]), conn);
                    comm.ExecuteNonQuery();
                }
            }
            else
            {
                comm = new MySqlCommand(String.Format(@"INSERT INTO `autors`(`BookId`) SELECT book.id FROM `book` WHERE book.Book = '{0}'", book.BookName), conn);
                comm.ExecuteNonQuery();
            }
            
            //Также добавляем запись в таблицу Авторы 
            comm = new MySqlCommand(String.Format(@"UPDATE `autors` SET `Autor` = '{0}' WHERE `BookId` = (SELECT `id` FROM `book` WHERE book.Book = '{1}')",book.Autors, book.BookName),conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

       //Удаление книги
        public static void RemoveBookFromBd(int id)
        {
            MySqlConnection conn = LibraryModel.ConnectToDb();
            MySqlCommand comm = new MySqlCommand(String.Format(@"DELETE FROM `book` WHERE `id` = {0}", id), conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        
    }
   
    //Описание книги (нужно для корректной работы формы добавления книг)
    public class Book
    {
        public  string BookName { get; set; }
        public  string Autors { get; set; }
        public  string IsAvaible { get; set; }
    }
}