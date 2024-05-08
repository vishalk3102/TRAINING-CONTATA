using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class Student
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int rollNo { get; set; }
        public DateOnly dob { get; set; }
    }
}
