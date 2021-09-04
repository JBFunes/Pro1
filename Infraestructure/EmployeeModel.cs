using Domain;
using System;

namespace Infraestructure
{
    public class EmployeeModel
    {
        private Employee[] employees;

        public EmployeeModel()
        {
        
        }
        public void Add(Employee employee)
        { if(employees == null)
            {
                employees = new Employee[1];
                employees[0] = employee;
                return;
            }
            Employee[] tmp = new Employee[employees.Length + 1];
            Array.Copy(employees, tmp, employees.Length);
            tmp[tmp.Length - 1] = employee;
            employees = tmp;
            
        }
        public Employee[] GetEmployees()
        {
            return employees;
        }

        #region Queriue

        public decimal GetSalarioMaximo()
        {
            decimal max = 0;
            foreach (Employee employee in employees)
            {
                if (employee.Wage > max)
                {
                    max = employee.Wage;
                }

            }
            return max;

            throw new NotImplementedException();
        }

        public decimal GetSalarioMinimo()
        {
            if(employees == null)
            {
                return 0;
            }
            if (employees.Length == 1)
            {
                return employees[0].Wage;
            }
            Array.Sort(employees,new Employee.EmployeeWageComparer());
            return employees[0].Wage;
        }

        public decimal GetSalarioPromedio()
        {
            decimal suma = 0M;
            if (employees == null)
            {
                return 0;
            }
            
            foreach (Employee e in employees)
            {
                suma += e.Wage;
            }
            return (suma/employees.Length);
        }

        public decimal GetSalarioEncimaPromedio()
        {
            decimal suma = 0M, maxProm = 0M;
            if(employees == null)
            {
                return 0;
            }

            foreach (Employee e in employees)
            {
                suma += e.Wage;
            }
            decimal promedio = suma / employees.Length;

            foreach (Employee employee in employees)
            {
                if (employee.Wage > promedio)
                {
                    maxProm = employee.Wage;
                }
            }
            return maxProm;
        }
        public decimal GetSalarioDebajoPromedio()
        {
            decimal suma = 0M, minProm = 0M;
            if (employees == null)
            {
                return 0;
            }

            foreach (Employee e in employees)
            {
                suma += e.Wage;
            }
            decimal promedio = suma / employees.Length;

            foreach (Employee employee in employees)
            {
                if (employee.Wage < promedio)
                {
                    minProm = employee.Wage;
                }
            }
            return minProm;
        }

            #endregion

        #region Private method

        private int EmployeeWageComparer(Employee e1, Employee e2)
        {
            if(e1 == null || e2 == null)
            {
                throw new ArgumentException("Error, los objetos no pueden ser null");
            }
            if (e1.Wage > e2.Wage)
            {
                return 1;

            } else if(e1.Wage < e2.Wage)
            {
                return -1;
            }
            else
            {
                return 0;
            }    
        }
        #endregion 
    }
}
