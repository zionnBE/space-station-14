using Content.Server.AI.WorldState;
using Content.Server.AI.WorldState.States;
using Content.Server.Chemistry.Components;

namespace Content.Server.AI.Utility.Considerations.Nutrition.Drink
{
    public sealed class DrinkValueCon : Consideration
    {
        protected override float GetScore(Blackboard context)
        {
            var target = context.GetState<TargetEntityState>().GetValue();

            if (target == null || target.Deleted || !target.TryGetComponent(out SolutionContainerComponent? drink))
            {
                return 0.0f;
            }

            var nutritionValue = 0;

            foreach (var reagent in drink.ReagentList)
            {
                // TODO
                nutritionValue += (reagent.Quantity * 30).Int();
            }

            return nutritionValue / 1000.0f;
        }
    }
}
