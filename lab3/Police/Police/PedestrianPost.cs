using System;

namespace Police
{
    //Listener realisation
    public class PedestrianPost : IPost
    {
        public int PostId { get; }
        private string _policeman1;
        private string _policeman2;

        public PedestrianPost(int postId, string policeman1, string policeman2)
        {
            PostId = postId;
            _policeman1 = policeman1;
            _policeman2 = policeman2;
        }

        public void Notify(int dispatcherId, Alert alert)
        {
            Console.WriteLine($"\nWoop! Woop! That's the sound of the beast!\nIt`s post #{PostId}, warming up!");
        }
    }
}