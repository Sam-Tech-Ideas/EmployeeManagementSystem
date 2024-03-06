 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models.Entities;


namespace EmployeeManagementSystem.Controllers
{

    public class EmployeesController : Controller
    {

        private readonly ApplicationDbContext dbContext;


        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
      [HttpGet]

      public IActionResult Add()
      {
        return View();
      }
        
      [HttpPost]

      public async Task<IActionResult> Add(AddEmployeeViewModel model)
      {
          if(ModelState.IsValid)
          {
              var employee = new Employee
              {
                  Name = model.Name,
                  Position = model.Position,
                  Email = model.Email,
                  Phone = model.Phone,
                  Salary = model.Salary
              };
              dbContext.Employees.Add(employee);
              await dbContext.SaveChangesAsync();
              return RedirectToAction("List");
          }
          return View(model);
      }
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var employees = await dbContext.Employees.ToListAsync();
        return View(employees);

    }
    

    }
    
}