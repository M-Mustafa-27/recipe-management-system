using System;
using System.Collections.Generic;

namespace E_Project_James_Thew.Models;

public partial class Membership
{
    public int MembershipId { get; set; }

    public string MName { get; set; } = null!;

    public string? MEmail { get; set; }

    public string MembershipPlan { get; set; } = null!;

    public int? UId { get; set; }

    public virtual UserAccount? UIdNavigation { get; set; }
}
