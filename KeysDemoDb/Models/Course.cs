using System;
using System.Collections.Generic;

namespace KeysDemoDb.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Points { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
