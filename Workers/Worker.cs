using System;
using System.Collections.Generic;
using System.Text;

namespace Workers
{
    public class Worker
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Profession { get; set; }
        public int Salary { get; set; }
        public decimal Score { get; set; }

        public string ToString()
        {
            return $"{FirstName} {MiddleName}, {Profession}, зарплата {Salary}";
        }
    }
}
