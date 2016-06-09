using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Library.Models
{
    /// <summary>
    /// История книги
    /// </summary>
    public  class BookHistoryModel
    {

        private  string bookName;

        public  string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
       
        public  DataTable hisDt { get; set; }
        
       //Показать историю книги (кто, когда брал и т.д.)
        public  void ShowBookHistory(int bookId, string inBookName)
        {
            
            hisDt = new DataTable();
            MySqlConnection conn = LibraryModel.ConnectToDb();
            MySqlCommand comm = new MySqlCommand(String.Format(@"SELECT * FROM `took_books` WHERE `BookID` = {0}", bookId), conn);
            conn.Open();
            comm.ExecuteNonQuery();
            MySqlDataAdapter dataAdap = new MySqlDataAdapter(comm);
            dataAdap.Fill(hisDt);
            conn.Close();
            bookName = inBookName;
        }
        
    }
}