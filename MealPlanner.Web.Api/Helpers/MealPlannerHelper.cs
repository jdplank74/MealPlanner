using MealPlanner.Business.Component;
using Domain = MealPlanner.Business.Domain;
using MealPlanner.Web.Mappings;
using Model = MealPlanner.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealPlanner.Web.Model;

namespace MealPlanner.Web.Api.Helpers
{
    public class MealPlannerHelper : IMealPlannerHelper
    {
        protected IMealPlannerComponent _component;
        protected MealPlannerModelMapper _mapper;
        public MealPlannerHelper(IMealPlannerComponent component, MealPlannerModelMapper mapper)
        {
            _component = component;
            _mapper = mapper;
        }

        public MealPlanLight CreateMealPlan(MealPlanLight mealPlan)
        {
            // Map to the domain model
            var mealPlanDomainModel = _mapper.Map<Domain.MealPlan>(mealPlan);

            mealPlanDomainModel = _component.CreateMealPlan(mealPlanDomainModel);

            // Map back to model
            var mealPlanModel = _mapper.Map<Model.MealPlanLight>(mealPlanDomainModel);
            return mealPlanModel;
        }

        public IEnumerable<MealPlanLight> GetMealPlans(Guid userId)
        {
            var mealPlanDomainModels = _component.GetMealPlans(userId);
            var mealPlanModels = _mapper.Map<IEnumerable<Model.MealPlanLight>>(mealPlanDomainModels);
            return mealPlanModels;
        }

        public IList<ScheduledMeal> GetScheduledMeals(int mealPlanId)
        {
            var scheduledMealDomainModels = _component.GetScheduledMeals(mealPlanId);
            var scheduledMealModels = _mapper.Map<IList<Model.ScheduledMeal>>(scheduledMealDomainModels);
            return scheduledMealModels;
        }

        public void UpdateMealPlan(MealPlanLight mealPlan)
        {
            // Map to domain model
            var mealPlanDomainModel = _mapper.Map<Domain.MealPlan>(mealPlan);

            _component.UpdateMealPlan(mealPlanDomainModel);
        }

        public IEnumerable<Model.Meal> GetMeals(Guid userId)
        {
            var mealDomainModels = _component.GetMeals(userId);
            var mealModels = _mapper.Map<IEnumerable<Model.Meal>>(mealDomainModels);
            return mealModels;
        }

        public Model.Meal CreateMeal(Model.Meal meal)
        {
            throw new NotImplementedException();
        }
    }
}
