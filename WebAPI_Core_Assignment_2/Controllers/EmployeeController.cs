using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Core_Assignment_2.Models;
using WebAPI_Core_Assignment_2.Repository;

namespace WebAPI_Core_Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _repo;

        public EmployeeController(IEmployee repo)
        {
            _repo = repo;
        }

        // getting the employee using the id
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            var emp = _repo.GetEmployeeById(id);
            if (emp == null)
                return NotFound();
            return Ok(emp);
        }

        // getting all employees here
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_repo.GetAllEmployees());
        }

        // getting the employee department here using the url route bydept
        [HttpGet("bydept")]
        public IActionResult GetEmployeesByDept([FromQuery] string dept)
        {
            return Ok(_repo.GetEmployeesByDept(dept));
        }

        // adding the employee 
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee emp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _repo.AddEmployee(emp);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = emp.Id }, emp);
        }

        // updating the employee using the put request with id in route url and data from the form
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] Employee emp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_repo.GetEmployeeById(id) == null)
                return NotFound();
            emp.Id = id;
            _repo.UpdateEmployee(emp);
            return NoContent();
        }

        // updating only one entity using the patch
        [HttpPatch("{id}/email")]
        public IActionResult UpdateEmployeeEmail([FromRoute] int id, [FromBody] string email)
        {
            if (_repo.GetEmployeeById(id) == null)
                return NotFound();
            _repo.UpdateEmployeeEmail(id, email);
            return NoContent();
        }

        // deleting the employee using id
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            if (_repo.GetEmployeeById(id) == null)
                return NotFound();
            _repo.DeleteEmployee(id);
            return NoContent();
        }

        // this will return 200 status code, which means, the current endpoint is active to give response to the user(client)
        [HttpHead]
        public IActionResult HeadEmployees() => Ok();

        // this says , these are the methods are allowed in this endpoint, useful for api testing....
        [HttpOptions]
        public IActionResult OptionsEmployees()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT,PATCH,DELETE,HEAD,OPTIONS");
            return Ok();
        }
    }
}
