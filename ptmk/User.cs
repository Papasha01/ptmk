using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ptmk
{
    public class User
    {
        public int Id { get; set; }
        public string? FIO { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }

        public int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            if (today < Birthday.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}
