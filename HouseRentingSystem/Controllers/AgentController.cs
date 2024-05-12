using HouseRentingSystem.Contracts.Agent;
using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Models.Agents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService _agents;

        public AgentController(IAgentService agents)
        {
            _agents = agents;
        }

        public async Task<IActionResult> Become()
        {
            var userId = User.Id();
            if (await _agents.ExistsById(userId))
            {
                return BadRequest();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel agent)
        {
            var userId = User.Id();
            if (await _agents.ExistsById(userId))
            {
                return BadRequest();
            }

            if (await _agents.UserWithPhoneNumberExists(agent.PhoneNumber))
            {
                ModelState.AddModelError(nameof(agent.PhoneNumber), "Phone number already exists. Enter another one.");
            }

            if (await _agents.UserHasRents(userId))
            {
                ModelState.AddModelError("Error", "You should have no rents to become an agent!");
            }

            if (!ModelState.IsValid)
            {
                return View(agent);
            }

            await _agents.Create(userId, agent.PhoneNumber);

            return RedirectToAction(nameof(HouseController.All), "Houses");
        }
    }
}
