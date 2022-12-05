using System;
using System.Collections.Generic;

namespace KeysDemoDb.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
