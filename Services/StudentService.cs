using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
public class StudentService : IStudentService
{

    private List<Student> _students = new List<Student>();
    private readonly IConfiguration _config;
    private readonly int _maxLimit;
    private readonly ILogger<StudentService> _logger;

    public StudentService(IConfiguration config, ILogger<StudentService> logger)
    {
        _config = config;
        _logger = logger;
        _maxLimit = _config.GetValue<int>("CollegeSettings:MaxStudentLimit");
    }
    public List<Student> GetAll()
    {
        _logger.LogInformation("Fetching all students");
        return _students;
    }
    
    public bool Add(Student student)
    {
        if(_students.Count >= _maxLimit)
        {
            _logger.LogWarning("Student limit reached. Cannot add more students.");
            return false;
        }
        student.Id = _students.Count + 1;
        _students.Add(student);
        _logger.LogInformation("Student added successfully.");
        return true;
    }

    public Student GetById(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            _logger.LogWarning("Invalid Id, the student Id should not be null or empty");
        }
        return student;
    }

    public bool Update(Student student)
    {
        var existing = GetById(student.Id);

        if(existing == null)
        {
            _logger.LogWarning("Invalid Id, Cannot update");
            return false;
        }

        existing.Name = student.Name;
        existing.Age = student.Age;
        existing.Department = student.Department;
        existing.Email = student.Email;

        _logger.LogInformation("Student Updated successfully.");

        return true;
    }
    public bool Delete(int id)
    {
        var student = GetById(id);

        if (student == null)
        {
            _logger.LogWarning("Invalid Id for delete");
            return false;
        }

        _students.Remove(student);

        _logger.LogInformation("Student deleted successfully.");

        return true;
    }
}