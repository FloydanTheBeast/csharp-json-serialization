using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Task_01
{
    [DataContract]
    class Student
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Year { get; set; }

        public Student(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
}
