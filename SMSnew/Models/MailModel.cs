﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSnew.Models
{
    public class MailModel
    {


        public string From
        {
            get;
            set;
        }
        public string To
        {
            get;
            set;
        }
        public string Subject
        {
            get;
            set;
        }
        public string Body
        {
            get;
            set;
        }
        public string CC
        {
            get;
            set;
        }
    }
}