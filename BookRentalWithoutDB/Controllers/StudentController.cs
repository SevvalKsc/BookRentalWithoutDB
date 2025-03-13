using BookRentalWithoutDB.Data;
using BookRentalWithoutDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalWithoutDB.Controllers;

public class StudentController : Controller
{
    public IActionResult Index()
    {
        StudentRespository repository = new StudentRespository();

        var students = repository.GetAllStudents();
        return View(students);
    }

    public IActionResult Detail(int id)
    {
        StudentRespository repository = new StudentRespository();
        var student = repository.GetStudent(id);
        if (student == null)
        {
            return NotFound();
        }
        else
        {
            return View(student);
        }
    }

    [HttpGet]
    public IActionResult Create()
    {
        StudentRespository repository = new StudentRespository();
        int newId = repository.GetAllStudents().Any() ? repository.GetAllStudents().Max(s => s.ID) + 1 : 1;
        var newStudent = new Student
        {
            ID = newId
        };
        return View(newStudent);
    }
    
    [HttpPost]
    public IActionResult Create(Student student)
    {
        StudentRespository repository = new StudentRespository();
        repository.Insert(student);
        return RedirectToAction("Index");
    }
    
    public IActionResult Edit(int id)
    {
        StudentRespository repository = new StudentRespository();
        var student = repository.GetStudent(id);
        if (student == null)
        {
            return NotFound();
        }
        else
        {
            return View(student);
        }
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        StudentRespository repository = new StudentRespository();
        repository.Update(student);
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(int id)
    {
        StudentRespository repository = new StudentRespository();
        var student = repository.GetStudent(id);
        repository.Delete(id);
        return RedirectToAction("Index");
    }
}