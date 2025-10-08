using WebAPI_Core_Assignment_2.Models;
using WebAPI_Core_Assignment_2.Repository;

namespace WebAPI_Core_Assignment_2.Repository
{
    public class EmployeeRepository : IEmployee
    {
        //Creating the employee object with default values
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Saravanan",
                Department = "CSE",
                MobileNo = "9876543210",
                Email = "john.doe@gamil.com",
            },
            new Employee
            {
                Id = 2,
                Name = "Santhosh Ram",
                Department = "HR",
                MobileNo = "9123456780",
                Email = "Santhosh.ram@gamil.com",
            },
            new Employee
            {
                Id = 3,
                Name = "Pandu",
                Department = "IT",
                MobileNo = "9988776655",
                Email = "pandu@gamil.com",
            },
            new Employee
            {
                Id = 4,
                Name = "Kishore",
                Department = "Finance",
                MobileNo = "9090909090",
                Email = "Kishore@gmail.com",
            },
        };
        //adding the emp object to the list 
        public void AddEmployee(Employee emp)
        {
            employees.Add(emp);
        }
        //Deleting the employee using the id
        public void DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
                employees.Remove(emp);
        }

        //returning all employees of type IEnumerable, because it is only for  reading 
        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees;
        }
        

        //Getting the employee using the id and returning the employee 
        public Employee? GetEmployeeById(int id)
        {
            //using the linq method to fetch the first employee with the respective id
            return employees.FirstOrDefault(e => e.Id == id);
        }


        //Getting the employee department
        public IEnumerable<Employee> GetEmployeesByDept(string dept)
        {
            //using the linq method to fetch the respective employee using the department
            return employees.Where(e => e.Department?.ToLower() == dept.ToLower());
        }
        //updating the all employee details except id
        public void UpdateEmployee(Employee emp)
        {
            var existing = employees.FirstOrDefault(e => e.Id == emp.Id);
            if (existing != null)
            {
                existing.Name = emp.Name;
                existing.Department = emp.Department;
                existing.MobileNo = emp.MobileNo;
                existing.Email = emp.Email;
            }
        }

        //updating the employee email using the id
        public void UpdateEmployeeEmail(int id, string email)
        {
            var existing = employees.FirstOrDefault(e => e.Id == id);
            if (existing != null)
            {
                existing.Email = email;
            }
        }
    }
}
