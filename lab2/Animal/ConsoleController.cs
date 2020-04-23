using System;
using System.Collections.Generic;

namespace Animal
{
    public class ConsoleController : IController
    {
        private readonly Dictionary<string, Animal> _animals = new Dictionary<string, Animal>();
        
        public void CreateAnimal(string view)
        {
            view = view[0].ToString().ToUpper() + view.ToLower().Substring(1);
            
            if (_animals.ContainsKey(view))
            {
                Console.WriteLine($"Animal of the {view} view already exists");
                return;
            }

            switch (view)
            {    
                case "Lion": 
                    _animals.Add("Lion", new ConcreteAnimal("Lion", 3, new AnimalTimer()));
                    break;
                
                case "Panda": 
                    _animals.Add("Panda", new ConcreteAnimal("Panda", 5, new AnimalTimer()));
                    break;
                
                case "Giraffe": 
                    _animals.Add("Giraffe", new ConcreteAnimal("Giraffe", 10, new AnimalTimer()));
                    break;
                
                default:
                    Console.WriteLine($"{view} can`t live in the zoo");
                    return;
            }
            
            Console.WriteLine($"{view} was set to the zoo\n");
        }

        public void FeedAnimal(string view)
        {
            view = view[0].ToString().ToUpper() + view.ToLower().Substring(1);
            
            if (_animals.ContainsKey(view))
            {
                Console.WriteLine("Enter the meal to feed: ");
                _animals[view].Feed(ReadLine());
                return;
            }
            
            Console.WriteLine($"{view} died for the diet");
        }

        public void DecorateAnimal(string view)
        {
            view = view[0].ToString().ToUpper() + view.ToLower().Substring(1);
            
            if (_animals.ContainsKey(view))
            {
                switch (view)
                {
                    case "Lion":
                        _animals["Lion"] = new LionDecorator(_animals["Lion"]);
                        break;
                    
                    case "Panda":
                        _animals["Panda"] = new PandaDecorator(_animals["Panda"]);
                        break;
                    
                    case "Giraffe":
                        _animals["Giraffe"] = new GiraffeDecorator(_animals["Giraffe"]);
                        break;
                }
                
                Console.WriteLine($"Feeder was set to the {view}`s cage");
                return;
            }
            
            Console.WriteLine($"{view} run away from the zoo");
        }
 
        public void SetMealPlan(string view)
        {
            view = view[0].ToString().ToUpper() + view.ToLower().Substring(1);
            
            if (_animals.ContainsKey(view))
            {
                Console.WriteLine($"Enter the meal plan for the {view}: ");
                _animals[view].MealPlan = ReadLine();
                return;
            }
            
            Console.WriteLine($"{view} disagreed to eat this");
        }

        private string ReadLine()
        {
            AnimalDecorator decorator;
            
            foreach (var keyValuePair in _animals) 
            {
                decorator = keyValuePair.Value as AnimalDecorator;
                
                if (decorator != null)
                {
                    decorator.Animal.AnimalTimer.SwitchFeedTimer();
                    decorator.Animal.AnimalTimer.SwitchAlertTimer();
                }
                else
                {
                    keyValuePair.Value.AnimalTimer.SwitchFeedTimer();
                    keyValuePair.Value.AnimalTimer.SwitchAlertTimer();
                }
            }

            string res = Console.ReadLine();
            Console.WriteLine();
            
            foreach (var keyValuePair in _animals) 
            {
                decorator = keyValuePair.Value as AnimalDecorator;
                
                if (decorator != null)
                {
                    decorator.Animal.AnimalTimer.SwitchFeedTimer();
                    decorator.Animal.AnimalTimer.SwitchAlertTimer();
                }
                else
                {
                    keyValuePair.Value.AnimalTimer.SwitchFeedTimer();
                    keyValuePair.Value.AnimalTimer.SwitchAlertTimer();
                }
            }

            return res;
        }

        public void Controll()
        {
            Console.WriteLine("Zoo menu: \n" +
                              "1 - Create new animal \n" +
                              "2 - Feed animal \n" +
                              "3 - Set a meal plan \n" +
                              "4 - Set a feeder \n" +
                              "0 - Quit \n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Enter the view of the animal: ");
                    CreateAnimal(ReadLine());
                    break;
                
                case "2":
                    Console.WriteLine("Enter the animal to feed: ");
                    FeedAnimal(ReadLine());
                    break;
                
                case "3":
                    Console.WriteLine("Enter the animal view: ");
                    SetMealPlan(ReadLine());
                    break;
                
                case "4":
                    Console.WriteLine("Enter the view of the animal: ");
                    DecorateAnimal(ReadLine());
                    break;
                
                case "0":
                    Console.WriteLine("Zoo is closing. Bye!");
                    return;
                
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            
            Controll();
        }
    }
}