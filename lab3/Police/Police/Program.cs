namespace Police
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a publisher
            Dispatcher dispatcher1 = new Dispatcher(1);
            
            // Creating listeners of different classes
            CarPost carPost1 = new CarPost(1, "Andrew Golovko", "Arsen Zadorozhniy", "Hyundai Elantra");
            CarPost carPost2 = new CarPost(2, "Ivan Zabuzniy", "Ihor Kucheruk", "Ford Mustang");
            
            PedestrianPost pedestrianPost1 = new PedestrianPost(3, "Grigoriy Sakunashvili", "Alexandr Usyk");
            
            HorsePost horsePost1 = new HorsePost(4, "Zhan Beleniuk", "Pedro");

            // Subscribing the created listeners on the publisher
            dispatcher1.Subscribe(carPost1.PostId, carPost1).Subscribe(carPost2.PostId, carPost2);
            dispatcher1.Subscribe(pedestrianPost1.PostId, pedestrianPost1);
            dispatcher1.Subscribe(horsePost1.PostId, horsePost1);
            
            // Creating an event
            dispatcher1.Inform("murder", "Ms. Jackson", "Baker Str. 177B", true);

            // Unsubscribing several listeners from the publisher
            dispatcher1.Unsubscribe(carPost1.PostId, carPost1).Unsubscribe(horsePost1.PostId, horsePost1);
            
            // Creating an event
            dispatcher1.Inform("parade", "Ministry of Culture", "Bankova Str.", false);
        }
    }
}