using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Project_James_Thew.Models
{
    public class ContestParticipationViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a contest")]
        public string SelectedContestName { get; set; }

        // For dropdown display
        public List<string> ContestNames { get; set; } = new List<string>();
    }
}
