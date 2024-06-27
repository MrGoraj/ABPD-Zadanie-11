using Microsoft.AspNetCore.Mvc;
using StudentWebApp.Context;
using StudentWebApp.Models;

namespace StudentWebApp.Controllers;

public class StudentsController : Controller
{
    public static List<Student> students = new List<Student>();

    static StudentsController()
    {
        students.Add(new Student
        {
            IdStudent = 1,
            FirstName = "John",
            LastName = "Kowalski",
            Email = "kowalski@wp.pl",
            Address = "Warsaw"
        });
        students.Add(new Student
        {
            IdStudent = 2,
            FirstName = "Anne",
            LastName = "Smith",
            Email = "smith@wp.pl",
            Address = "Warsaw"
        });
    }
    
    // GET
    public IActionResult Index(string query)
    {
        if (!string.IsNullOrWhiteSpace(query))
        {
            return View(students.Where(s => s.LastName.Contains(query)).ToList());
        }
        
        return View(students);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Student newStudent)
    {
        if (ModelState.IsValid)
        {
            students.Add(newStudent);
            return RedirectToAction("Index");
        }
        
        return View(newStudent);
    }
    
}