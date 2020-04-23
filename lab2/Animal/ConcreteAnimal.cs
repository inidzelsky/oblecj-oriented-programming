using System;

namespace Animal
{
    public class ConcreteAnimal : Animal
    {
        // General constructor
        public ConcreteAnimal(string view, int feedTimeOut, AnimalTimer animalTimer)
            : base(view, feedTimeOut, animalTimer)
        {
        }

        // Implementation of the abstract Feed method
        public override void Feed(string food)
        {
            if (MealPlan == null)
            {
                Console.WriteLine("MealPlan was not set");
                return;
            }
            
            if (!MealPlan.ToLower().Equals(food.ToLower()))
            {
                Console.WriteLine($"{View} can`t eat {food}");
                return;
            }
                
            AnimalTimer.SetHungryTimer(this);
            Console.WriteLine($"{View} was fed");
        }
    }
}