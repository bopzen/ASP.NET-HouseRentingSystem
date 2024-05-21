using HouseRentingSystem.Contracts.House;
using HouseRentingSystem.Data;
using HouseRentingSystem.Models.Houses;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.House
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext _data;

        public HouseService(HouseRentingDbContext data)
        {
            _data = data;
        }

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategories()
        {
            return _data
                    .Categories
                    .Select(c => new HouseCategoryServiceModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToList();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await _data.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> Create(string title, string address, string description, string imageUrl, decimal price, int categoryId, int agentId)
        {
            var house = new HouseRentingSystem.Data.Models.House()
            {
                Title = title,
                Address = address,
                Description = description,
                ImageUrl = imageUrl,
                PricePerMonth = price,
                CategoryId = categoryId,
                AgentId = agentId
            };

            await _data.Houses.AddAsync(house);
            await _data.SaveChangesAsync();

            return house.Id;
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
        {
            return _data
                .Houses
                .OrderByDescending(c => c.Id)
                .Select(c => new HouseIndexServiceModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImageUrl = c.ImageUrl,
                })
                .Take(3);
        }
    }
}
