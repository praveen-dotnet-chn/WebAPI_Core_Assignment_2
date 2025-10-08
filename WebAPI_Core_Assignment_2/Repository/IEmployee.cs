using WebAPI_Core_Assignment_2.Models;

namespace WebAPI_Core_Assignment_2.Repository
{
    public interface IEmployee
    {
        //having the basic methods here
        Employee? GetEmployeeById(int id);
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetEmployeesByDept(string dept);
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void UpdateEmployeeEmail(int id, string email);
        void DeleteEmployee(int id);
    }
}

