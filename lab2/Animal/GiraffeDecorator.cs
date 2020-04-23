namespace Animal
{
    public class GiraffeDecorator : AnimalDecorator
    {
        public GiraffeDecorator(Animal animal) : base(animal)
        {
            FeedWrapper();
        }

        private void FeedWrapper()
        {
            Animal.MealPlan = "Leaves";
            Feed("Leaves");
        }
    }
}