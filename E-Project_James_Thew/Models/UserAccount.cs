using System;
using System.Collections.Generic;

namespace E_Project_James_Thew.Models;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? UserEmail { get; set; }

    public string UserPassword { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public int? RId { get; set; }

    public virtual ICollection<ContestParticipant> ContestParticipants { get; set; } = new List<ContestParticipant>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();

    public virtual Role? RIdNavigation { get; set; }
}
