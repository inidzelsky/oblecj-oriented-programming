namespace Animal
{
    public class PandaDecorator : AnimalDecorator
    {
        public PandaDecorator(Animal animal) : base(animal)
        {
            FeedWrapper();
        }
        
        private void FeedWrapper()
        {
            Animal.MealPlan = "Bamboo";
            Feed("Bamboo");
        }
    }
}