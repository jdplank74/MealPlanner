using MealPlanner.Web.Api.Helpers;
using MealPlanner.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utils = Utilities.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MealPlanner.Web.Api.Controllers
{
    [Route("api/{controller}")]
    public class MealsController : ControllerBase
    {
        private readonly IMealPlannerHelper _helper;
        private readonly ILogger _logger = Utils.LoggerFactory.CreateLogger<MealPlansController>();

        public MealsController(IMealPlannerHelper helper)
        {
            _helper = helper;
        }

        [HttpGet]
        [Route("{userId:Guid}")]
        public IActionResult GetMeals(Guid userId)
        {
            IActionResult actionResult = null;

            var meals = _helper.GetMeals(userId);

            if(meals.Count() > 0)
            {
                actionResult = new OkObjectResult(meals);
            }
            else
            {
                actionResult = new NotFoundResult();
            }
            return actionResult;
        }

        [HttpPost]
        public IActionResult CreateMeal(Meal meal)
        {
            IActionResult actionResult = null;

            var createdMeal = _helper.CreateMeal(meal);

            actionResult = new CreatedResult(createdMeal.Id.ToString(), createdMeal);
            return actionResult;
        }
    }
}
