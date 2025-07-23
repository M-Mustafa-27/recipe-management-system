using System;
using System.Collections.Generic;

namespace E_Project_James_Thew.Models;

using System.ComponentModel.DataAnnotations.Schema;

public partial class Contest
{
    public int ContestId { get; set; }

    public string? ContestTitle { get; set; }

    public string? ContestName { get; set; }

    public string? ContestDescription { get; set; }

    public DateOnly? ContestDate { get; set; }
}

