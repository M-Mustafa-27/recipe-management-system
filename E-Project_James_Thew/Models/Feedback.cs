using System;
using System.Collections.Generic;

namespace E_Project_James_Thew.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string? FeedbackMsg { get; set; }

    public int? UId { get; set; }

    public virtual UserAccount? UIdNavigation { get; set; }
}
