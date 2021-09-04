using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Employee
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Dni { get; set; }
        [JsonProperty]
        public string Names { get; set; }
        [JsonProperty]
        public string Lastnames { get; set; }
        [JsonProperty]
        public decimal Wage { get; set; }
        [JsonProperty]
        public AcademicLevel AcademicLevel { get; set; }
        [JsonProperty]
        public Gender Gender { get; set; }

        public class EmployeeWageComparer : IComparer<Employee>
        {
            public int Compare(Employee e1, Employee e2)
            {
                if (e1 == null || e2 == null)
                {
                    throw new ArgumentException("Error, los objetos no pueden ser null");
                }
                if (e1.Wage > e2.Wage)
                {
                    return 1;

                }
                else if (e1.Wage < e2.Wage)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public class EmployeeAcademicLevelComparer : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {

                if(x==null || y == null)
                {
                    throw new ArgumentException("Empleados no pueden ser null.");
                }

                if (x.AcademicLevel > y.AcademicLevel)
                {
                    return 1;

                } else if(x.AcademicLevel < y.AcademicLevel)
                {
                    return -1;

                } else
                {
                    return 0;
                }
            }
        }

        public class EmployeeLastnameComparer : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return x.Lastnames.CompareTo(y.Lastnames);
            }
        }

    }
}
