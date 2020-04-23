namespace Animal
{
    public class LionDecorator : AnimalDecorator
    {
        public LionDecorator(Animal animal) : base(animal)
        {
            FeedWrapper();
        }

        private void FeedWrapper()
        {
            Animal.MealPlan = "Meat";
            Feed("Meat");
        }
    }
}

