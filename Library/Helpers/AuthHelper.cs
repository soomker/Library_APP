using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;

namespace Library.Helpers
{
    public class AuthHelper
    {
        public static bool IsLogged { get; set; }
       

        static void SetLogged()
        {
            IsLogged = true;
        }

       static void SetUnLogged()
        {
            IsLogged = false;
        }
        
        public static void LogInUser(HttpContextBase httpContext, string cookies)
        {
            var cookie = new HttpCookie("__AUTH") { Value = cookies, Expires = DateTime.Now.AddYears(1) };

            httpContext.Response.Cookies.Add(cookie);
        }

        public static void LogOffUser(HttpContextBase httpContext)
        {
            if (httpContext.Request.Cookies["__AUTH"] != null)
            {
                var cookie = new HttpCookie("__AUTH") { Expires = DateTime.Now.AddDays(-1) };

                httpContext.Response.Cookies.Add(cookie);
            }
        }

        public static string GetUser(HttpContextBase httpContext)
        {
            var authCookie = httpContext.Request.Cookies["__AUTH"];

            if (authCookie != null)
            {
                string user = authCookie.Value;

                return user;
            }

            return null;
        }

        public static bool IsAuthenticated(HttpContextBase httpContext)
        {
            var authCookie = httpContext.Request.Cookies["__AUTH"];

            if (authCookie != null)
            {
                SetLogged();
                return true;
            }

            else
            {
                SetUnLogged();
                return false; 
            }
        }
    }
}