﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    /// <summary>
    /// Модель для отправки Email взявшему книгу
    /// </summary>
    public class EmailModel
    {
        public  string Subject { get; set; }

        public  string From { get; set; }

        public   string To { get; set; }

        public  string Body { get; set; }
    }
}