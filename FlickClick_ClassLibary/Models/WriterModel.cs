using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlickClick_ClassLibary.Models
{
    public class WriterModel : IPeople
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}