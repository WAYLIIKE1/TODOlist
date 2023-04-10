using System;
using System.Collections.Generic;

namespace Todolist.Data.Models;

public class Category
{
    public int IdCat { get; set; }

    public string NameCat { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
