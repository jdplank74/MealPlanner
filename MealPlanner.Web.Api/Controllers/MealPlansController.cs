using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealPlanner.Business.Component;
using Domain = MealPlanner.Business.Domain;
using MealPlanner.Web.Api.Helpers;
using MealPlanner.Web.Mappings;
using Model = MealPlanner.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utils = Utilities.Logging;

namespace MealPlanner.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealPlansController : ControllerBase
    {
        private readonly ILogger _logger = Utils.LoggerFactory.CreateLogger<MealPlansController>();

        private readonly IMealPlannerHelper _helper;

        public MealPlansController(IMealPlannerHelper helper)
        {
            _helper = helper;
        }

        [HttpGet]
        [Route("{userId:guid}")]
        public IActionResult GetMealPlans(Guid userId)
        {
            IActionResult actionResult = null;

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogInformation($"Getting mealplans for User with userId {userId}");
            }

            var mealPlanModels = _helper.GetMealPlans(userId);

            if (mealPlanModels.Count() > 0)
            {
                actionResult = new OkObjectResult(mealPlanModels);
            }
            else
            {
                actionResult = new NotFoundResult();
            }

            return actionResult;
        }

        [HttpGet]
        [Route("{mealPlanId:int}/scheduledmeals")]
        public IActionResult GetScheduledMeals(int mealPlanId)
        {
            IActionResult actionResult = null;
            if(_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"Getting scheduled meals for meal plan with with id {mealPlanId}");
            }

            var scheduledMealModels = _helper.GetScheduledMeals(mealPlanId);
            
            if(scheduledMealModels.Count() > 0)
            {
                actionResult = new OkObjectResult(scheduledMealModels);
            }
            else
            {
                actionResult = new NotFoundResult();
            }
            return actionResult;
        }

        [HttpPost]
        public IActionResult CreateMealPlan(Model.MealPlanLight mealPlan)
        {
            IActionResult actionResult = null;

            var mealPlanModel = _helper.CreateMealPlan(mealPlan);

            actionResult = new CreatedResult(mealPlanModel.Id.ToString(), mealPlanModel);

            return actionResult;
        }

        [HttpPut]
        [Route("{mealPlanId:int}")]
        public IActionResult UpdateMealPlan(Model.MealPlanLight mealPlan)
        {
            IActionResult actionResult = null;

            _helper.UpdateMealPlan(mealPlan);

            actionResult = new NoContentResult();
            return actionResult;
        }


    }
}