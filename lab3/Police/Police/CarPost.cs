using System;

namespace Police
{
    //Listener realisation
    public class CarPost : IPost
    {
        public int PostId { get; }
        private string _policeman1;
        private string _policeman2;
        private string _car;

        public CarPost(int postId, string policeman1, string policeman2, string car)
        {
            PostId = postId;
            _policeman1 = policeman1;
            _policeman2 = policeman2;
            _car = car;
        }
        
        public void Notify(int dispatcherId, Alert alert)
        {
            Console.WriteLine($"\nWoop! Woop! That's the sound of the beast!\nIt`s post #{PostId}, starting the {_car}!");
        }
    }
}