using System;
using System.Collections.Generic;

namespace PeopleFinder
{
    public class Model
    {
        public class Employee
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class RootObject
        {
            public List<Employee> employees { get; set; }


        }

    }
}
