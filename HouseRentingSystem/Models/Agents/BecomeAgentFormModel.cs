using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Data.DataConstraints.Agent;

namespace HouseRentingSystem.Models.Agents
{
    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(AgentPhoneNumberMaxLength, MinimumLength = AgentPhoneNumerMinLength)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
