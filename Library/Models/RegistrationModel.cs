using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
namespace Library.Models
{
    /// <summary>
    /// Модель для регисрации юзеров
    /// </summary>
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Type your email!")]
        public virtual string Email { get; set; }

       //Добавление юзеров в базу
        public static void AddUserToDB(User usr)
        {
            MySqlConnection conn = LibraryModel.ConnectToDb();
            MySqlCommand comm = new MySqlCommand(String.Format(@"INSERT INTO `users`(`Email`) VALUES ('{0}')",usr.Email),conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }

    public class User
    {
        public string Email { get; set; }

    }

   
}