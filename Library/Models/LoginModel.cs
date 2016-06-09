using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
   /// <summary>
   /// Модель для логина
   /// </summary>
    public class LoginModel
    {
        [Required(ErrorMessage = "Type your email!")]
        public virtual string Email { get; set; }
        
        //Проверка сущестования юзера по записи в базе
        public static bool IsUserExists(LogUsr lUsr)
        {
            MySqlConnection conn = LibraryModel.ConnectToDb();
            MySqlCommand comm = new MySqlCommand(String.Format(@"SELECT `Email` FROM `users` WHERE `Email` = '{0}'", lUsr.Email), conn);
            conn.Open();
            try
            {
                string usrEm = comm.ExecuteScalar().ToString();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
    }
    public class LogUsr
    {
        public string Email { get; set; }
    }
}