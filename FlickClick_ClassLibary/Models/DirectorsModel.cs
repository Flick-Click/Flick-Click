﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.Models
{
    public class DirectorsModel: IPeople
    {
        public int MovieID { get; set; }
        public int PeopleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}