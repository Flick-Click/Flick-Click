﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class WriterModel : IPeople
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}