using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public interface IStudentService
{
    List<Student> GetAll();
    Student GetById(int id);
    bool Add(Student student);
    bool Update(Student student);
    bool Delete(int id);

}