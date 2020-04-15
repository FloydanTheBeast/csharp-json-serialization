using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    [DataContract]
    class Group
    {
        [DataMember]
        public string Ident { get; set; }

        [DataMember]
        public Student[] List { get; set; }

        public Group(string id, Student[] list)
        {
            this.Ident = id;
            this.List = list;
        }

        public override string ToString()
        {
            string temp = Ident + ": ";
            Array.ForEach<Student>(List, (st) =>
                temp += st.Name + "-" + st.Year + "\n");
            return temp;
        }
    }
}
