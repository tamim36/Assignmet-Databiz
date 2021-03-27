using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebService.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.Include(c => c.Department).ToListAsync());
        }

        // GET: Employee/Create
        public IActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
                return View(_context.Employees.Find(id));
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("EmployeeId,Name,DepartmentId,PhoneNo,Address")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Department = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == employee.DepartmentId);
                if (employee.EmployeeId == 0)
                    _context.Add(employee);
                else
                    _context.Update(employee);

                

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
