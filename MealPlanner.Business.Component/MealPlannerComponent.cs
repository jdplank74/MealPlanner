using Model = MealPlanner.Business.Domain;
using MealPlanner.DataAccess.Repository;
using Microsoft.Extensions.Logging;
using Entity = MealPlanner.Database.Entity;
using MealPlanner.Mappings;
using System;
using System.Collections.Generic;
using Utils = Utilities.Logging;
using Utilities.Mapper;



namespace MealPlanner.Business.Component
{
    
    public class MealPlannerComponent : IMealPlannerComponent
    {
        private ILogger _logger = Utils.LoggerFactory.CreateLogger<MealPlannerComponent>();

        protected IMealPlannerRepository _repository;
        protected MealPlannerDomainMapper _mapper;

        public MealPlannerComponent(IMealPlannerRepository repository,MealPlannerDomainMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Model.MealPlan> GetMealPlans(Guid userId)
        {
            _logger.LogInformation("This is a test of the logging");
            IEnumerable<Entity.MealPlan> mealPlanEntities =_repository.GetMealPlansByUser(userId);
            var mealPlanModels = _mapper.Map<List<Model.MealPlan>>(mealPlanEntities);
            return mealPlanModels;
        }

        public IList<Model.ScheduledMeal> GetScheduledMeals(int mealPlanId)
        {
            var scheduledMealEntities = _repository.GetScheduledMeals(mealPlanId);
            var scheduledMealModels = _mapper.Map<IList<Model.ScheduledMeal>>(scheduledMealEntities);
            return scheduledMealModels;
        }

        public Model.MealPlan CreateMealPlan(Model.MealPlan mealPlan)
        {
            var mealPlanEntity = _mapper.Map<Entity.MealPlan>(mealPlan);

            Entity.User owner = _repository.GetUser(mealPlan.OwnerId);
            mealPlanEntity.Owner = owner;

            mealPlanEntity = _repository.AddMealPlan(mealPlanEntity);

            var mealPlanDomain = _mapper.Map<Domain.MealPlan>(mealPlanEntity);

            return mealPlanDomain;
        }

        public void UpdateMealPlan(Model.MealPlan mealPlan)
        {
            var updateEntity = _mapper.Map<Entity.MealPlan>(mealPlan);

            var mealPlanEntityToUpdate = _repository.GetMealPlanById(mealPlan.Id);

            if(OverlayUpdateValues(updateEntity, mealPlanEntityToUpdate))
            {
                _repository.UpdateMealPlan(mealPlanEntityToUpdate);
            }
        }

        public bool OverlayUpdateValues(Entity.MealPlan updateSource,Entity.MealPlan updateTarget)
        {
            bool wasUpdated = false;
            if(AreDifferent(updateSource.Name,updateTarget.Name))
            {
                updateTarget.Name = updateSource.Name;
                wasUpdated = true;
            }

            if (AreDifferent(updateSource.Description, updateTarget.Description))
            {
                updateTarget.Description = updateSource.Description;
                wasUpdated = true;
            }

            if (updateSource.StartDate != updateTarget.StartDate)
            {
                updateTarget.StartDate = updateSource.StartDate;
                wasUpdated = true;
            }
            return wasUpdated;
        }

        private bool AreDifferent(string str1,string str2)
        {
            bool areDifferent = false;
            if((string.IsNullOrEmpty(str1) && !string.IsNullOrEmpty(str2)) ||
                (!string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2)))
            {
                areDifferent = true;
            }
            else if(!str1.Equals(str2))
            {
                areDifferent = true;
            }
            return areDifferent;
        }

        public IEnumerable<Domain.Meal> GetMeals(Guid userId)
        {
            var mealEntityList = _repository.GetMeals(userId);
            var mealDomainList = _mapper.Map<IList<Model.Meal>>(mealEntityList);
            return mealDomainList;
        }
    }
}
