namespace Animal
{
    public interface IController
    {
        void CreateAnimal(string view);
        void FeedAnimal(string view);
        void DecorateAnimal(string view);
        void SetMealPlan(string view);
    }
}