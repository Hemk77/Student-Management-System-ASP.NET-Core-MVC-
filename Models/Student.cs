using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Student
{
    public int Id { get; set; }
    [Required]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Name must contain only letters")]
    public string Name { get; set; } = string.Empty;
    [Range(18,60)]
    public int Age { get; set; }
    [Required]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Enter the valid department")]
    public string Department { get; set; }
    [EmailAddress]
    public string Email { get; set; }

}