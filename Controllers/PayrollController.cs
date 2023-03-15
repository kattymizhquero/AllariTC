using Microsoft.AspNetCore.Mvc;
using PayRoll.Data;
using PayRoll.Models;

namespace PayRoll.Controllers
{
    public class PayrollController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PayrollController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Blog/Post
        [HttpGet]
        public IActionResult Employee()
        {
            _dbContext.Add(
                new Employee()
                {
                    Name = "Jaime Pinto",
                    Email = "jaime.pinto@gmail.com"
                }
                );
            _dbContext.SaveChanges();
            var _model = new EmployeeViewModel()
            {
                Employee = new Employee(),
                EmployeeList = _dbContext.Employees.OrderByDescending(x => x.Name).ToList()
            };
            return View(_model);
        }

        // POST: Blog/Post
        [HttpPost]
        public IActionResult Employee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(employee);
                _dbContext.SaveChanges();
                return PartialView("_EmployeeListPartial",
                    _dbContext.Employees.OrderBy(x => x.Name).ToList());
            }
            else
            {
                return null;
            }
        }
    }
}
