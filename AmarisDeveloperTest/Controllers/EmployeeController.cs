using AmarisDeveloperTest.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace AmarisDeveloperTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeLogic employeeLogic;

        public EmployeeController(EmployeeLogic employeeLogic)
        {
            this.employeeLogic = employeeLogic;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await employeeLogic.GetEmployees();
            return Ok(employees);
        }
    }
}
