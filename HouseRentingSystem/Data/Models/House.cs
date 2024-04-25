using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using static HouseRentingSystem.Data.DataConstraints.House;

namespace HouseRentingSystem.Data.Models
{
    public class House
    {
        public int Id { get; set; }

        [Required]
        [MinLength(HouseTitleMinLength)]
        [MaxLength(HouseTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(HouseAddressMinLength)]
        [MaxLength(HouseAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MinLength(HouseDescriptionMinLength)]
        [MaxLength(HouseDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(HousePricePerMonthMinValue, HousePricePerMonthMaxValue)]
        public decimal PricePerMonth { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Agent))]
        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; } = null!;

        [ForeignKey(nameof(Renter))]
        public string? RenterId { get; set; } = null!;
        public IdentityUser? Renter { get; set; } = null!;

    }
}
