using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiService.Contracts.Models
{
    public class Employee
    {
      //  [Key]

        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string email { get; set; }
        public string gender { get; set; }

    }
}
