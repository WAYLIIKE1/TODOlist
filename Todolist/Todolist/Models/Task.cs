using System;
using System.Collections.Generic;

namespace Todolist.Data.Models;

public class Task
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime DueDate { get; set; }

    public bool IsCompleted { get; set; }

    public int IdCat { get; set; }

    public virtual Category IdCatNavigation { get; set; } = null!;
}
