using System;
using System.Collections.Generic;

namespace EngDesk.Models;

public partial class Employee
{
    public int Employeeid { get; set; }

    public string? EmployeeName { get; set; }

    public string? City { get; set; }

    public DateTime? DateofJoining { get; set; }

    public decimal Salary { get; set; }
}
