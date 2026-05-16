using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller
{
    private readonly IStudentService _service;
    private readonly IConfiguration _config;

    public StudentController(IStudentService service, IConfiguration config)
    {
        _service = service;
        _config = config;
    }

    public IActionResult Index()
    {
        var students = _service.GetAll();
        ViewBag.CollegeName = _config["CollegeSettings:CollegeName"];
        return View(students);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        var result = _service.Add(student);

        if (!result)
        {
            ModelState.AddModelError("", "Student limit reached");
            return View(student);
        }

        TempData["Success"] = "Student added successfully!";
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var student = _service.GetById(id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    public IActionResult Edit(int id)
    {
        var student = _service.GetById(id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        var result = _service.Update(student);

        if (!result)
        {
            return NotFound();
        }

        TempData["Success"] = "Student updated successfully!";
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var student = _service.GetById(id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var result = _service.Delete(id);

        if (!result)
        {
            return NotFound();
        }

        TempData["Success"] = "Student deleted successfully!";
        return RedirectToAction("Index");
    }
}