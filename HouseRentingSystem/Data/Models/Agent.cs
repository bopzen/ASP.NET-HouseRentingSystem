using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Data.DataConstraints.Agent; 

namespace HouseRentingSystem.Data.Models
{
    public class Agent
    {
        public int Id { get; set; }

        [Required]
        [MinLength(AgentPhoneNumerMinLength)]
        [MaxLength(AgentPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public IdentityUser User { get; set; } = null!;
    }
}
