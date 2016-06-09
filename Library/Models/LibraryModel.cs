using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;


namespace Library.Models
{
    /// <summary>
    /// Основаня модель библиотеки
    /// </summary>
    public class LibraryModel
    {

        [Required(ErrorMessage = "Type the Email!!!")]
        public string Email { get; set;}
    //Метод для подключения к базе
        public  static MySqlConnection ConnectToDb()
        {
            MySqlConnectionStringBuilder msConnStr = new MySqlConnectionStringBuilder();
            msConnStr.Server = "localhost";
            msConnStr.Database = "library_base";
            msConnStr.UserID = "root";
            msConnStr.Password = String.Empty;
            MySqlConnection connect = new MySqlConnection();
            connect.ConnectionString = msConnStr.ConnectionString;
            return connect;
        }

        //Получение списка взятых юзерами книг
        public DataTable GetBooksTakenByUser(string user)
        {
            DataTable sortByUser = new DataTable();
            MySqlConnection conn = ConnectToDb();
            MySqlCommand comm = new MySqlCommand(String.Format(@"SELECT `BookId`, `Date` FROM `took_books` 
                                                               WHERE `Login` = '{0}' GROUP BY `BookId`",user),conn);
            conn.Open();
            comm.ExecuteNonQuery();
            MySqlDataAdapter adap = new MySqlDataAdapter(comm);
            adap.Fill(sortByUser);
            sortByUser.Columns.Add("BookName");
            foreach (DataRow row in sortByUser.Rows)
            {
                comm = new MySqlCommand(String.Format(@"SELECT `Book` FROM `book` WHERE `id` = {0}",row["BookId"]),conn);
                //Книгу могли удалить, в то время когда она была взята юзером, ссотвественно
                //в истории она останется, а в общем списке книг ее не будет
                //чтоб не было конфуза с пустым именем книги в списке "Взятых книг" трем строку если не получили имя книги
                if (comm.ExecuteScalar() != null) row["BookName"] = comm.ExecuteScalar().ToString();
                else row.Delete();
            }
            sortByUser.AcceptChanges();
            conn.Close();
            return sortByUser;
        }
       
        //Получение списка доступных книг
        public DataTable GetAvaibleBooks()
        {
            DataTable sortDt = new DataTable();
            MySqlConnection conn = ConnectToDb();
            MySqlCommand comm = new MySqlCommand(@"SELECT book.id,book.Book,book.IsAvailable, GROUP_CONCAT(autors.Autor) as `Autor`  
                                                  FROM `book`,`autors` 
                                                  WHERE book.id = autors.BookId and 
                                                  book.IsAvailable = 'true' GROUP BY autors.BookId ", conn);
            conn.Open();
            comm.ExecuteNonQuery();
            MySqlDataAdapter adap = new MySqlDataAdapter(comm);
            adap.Fill(sortDt);
            conn.Close();
            return sortDt;
        }

     //Получение всех книг в библиотеке (для главной страницы)
        public  DataTable GetDataTableFromDb()
        {
            DataTable bookTd = new DataTable();
            MySqlConnection mysqlConn = ConnectToDb();
            MySqlCommand comm = new MySqlCommand(@"SELECT book.id,book.Book,book.IsAvailable, GROUP_CONCAT(autors.Autor) as `Autor`  
                                                  FROM `book`,`autors` 
                                                  WHERE book.id = autors.BookId GROUP BY autors.BookId", mysqlConn);
            mysqlConn.Open();
            comm.ExecuteNonQuery();
            MySqlDataAdapter dataAdap = new MySqlDataAdapter(comm);
            dataAdap.Fill(bookTd);
            mysqlConn.Close();
           
            return bookTd;
        }

     //Метод "Взять книгу из библиотеки"
        public static void TakeBook (string user, int bookId)
        {
            MySqlConnection conn = ConnectToDb();
            MySqlCommand comm = new MySqlCommand(String.Format(@"INSERT INTO `took_books`(`Action`,`Login`, `BookID`, `Date`) VALUES ('Taken','{0}','{1}','{2}')", user, bookId, DateTime.Now.ToString()), conn);
            conn.Open();
            comm.ExecuteNonQuery();
            comm = new MySqlCommand(String.Format(@"UPDATE `book` SET `IsAvailable` = 'false' WHERE `id` = {0}", bookId), conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }


        
    }
}