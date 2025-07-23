using System;
using System.Collections.Generic;

namespace E_Project_James_Thew.Models;

public partial class ContestParticipant
{
    public int PId { get; set; }

    public int? UserId { get; set; }

    public virtual UserAccount? User { get; set; }
}
