using System;

namespace Police
{
    //Listener realisation
    public class HorsePost : IPost
    {
        public int PostId { get; }
        private string _policeman1;
        private string _horseName;

        public HorsePost(int postId, string policeman1, string horseName)
        {
            PostId = postId;
            _policeman1 = policeman1;
            _horseName = horseName;
        }

        public void Notify(int dispatcherId, Alert alert)
        {
            Console.WriteLine($"\nWoop! Woop! That's the sound of the beast!\nIt`s post #{PostId}, search for horseshoes!");
        }
    }
}