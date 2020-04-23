namespace Animal
{
    public abstract class Animal
    {
        //Object fields
        public string View { get; }
        public int FeedTimeOut { get; }
        public string MealPlan;

        //System fields
        public AnimalTimer AnimalTimer { get; }
        
        //Constructor initializes only object fields
        public Animal(string view, int feedTimeOut, AnimalTimer animalTimer)
        {
            View = view;
            FeedTimeOut = feedTimeOut;
            AnimalTimer = animalTimer;
            
            //Setting the timer of hunger
            AnimalTimer.SetHungryTimer(this);
        }

        //Decorator constructor
        public Animal()
        {
        }

        //Methods to be implemented by base class and decorators
        public abstract void Feed(string food);
    }
}