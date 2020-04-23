namespace Animal
{
    public abstract class AnimalDecorator : Animal
    { 
        public Animal Animal { get; }
        
        public AnimalDecorator(Animal animal) : base()
        {
            Animal = animal;
        }

        // Feeds animal automatically
        public override void Feed(string food)
        {
            Animal.AnimalTimer.SetFeedTimer(Animal);
        }
    }
}