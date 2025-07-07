using CRUD.Models.Entites;
using CRUD.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class EmployeController : Controller
{
    private readonly IEmployeService _employeService;

    public EmployeController(IEmployeService employeService)
    {
        _employeService = employeService;
    }

    // GET: Employes
    public async Task<IActionResult> Index()
    {
        var employes = await _employeService.GetAllEmployes();
        return View(employes);
    }

    // GET: Employes/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var emp = await _employeService.GetEmployeByEmployeId(id);
        if (emp == null)
        {
            return NotFound();
        }
        return View(emp);
    }

    // GET: Employes/Create
    [Authorize(Roles = "User")]

    public IActionResult Create()
    {
        return View(new Employe());
    }

    // POST: Employes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Employe employe)
    {
        if (ModelState.IsValid)
        {
            await _employeService.AddEmployee(employe);
            return RedirectToAction("Index", "Employe");
        }
        return View(employe);
    }

    [Authorize(Roles = "User")]

    // GET: Employes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var employe = await _employeService.GetEmployeByEmployeId(id.Value);
        if (employe == null)
            return NotFound();

        return View(employe);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Employe employe)
    {
        if (id != employe.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            await _employeService.UpdateEmploye(employe);
            return RedirectToAction("Index", "Employe");
        }
        return View(employe);
    }

    [Authorize(Roles = "User")]
    // GET: Employes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var employe = await _employeService.GetEmployeByEmployeId(id.Value);
        if (employe == null)
            return NotFound();

        return View(employe);
    }

    // POST: Employes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var success = await _employeService.DeleteEmploye(id);
        if (!success)
            return NotFound();

        return RedirectToAction("Index","Employe");
    }
}
