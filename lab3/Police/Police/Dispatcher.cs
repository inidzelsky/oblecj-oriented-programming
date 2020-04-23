using System;
using System.Collections.Generic;

namespace Police
{
    public class Dispatcher
    {
        public int DispatcherId { get; }
        
        // List for saving listeners
        private List<IPost> _posts;

        public Dispatcher(int dispatcherId)
        {
            DispatcherId = dispatcherId;
            _posts = new List<IPost>();
        }

        // Subscribes listener on the publisher
        public Dispatcher Subscribe(int postId, IPost post)
        {
            Console.WriteLine($"Post #{postId} was added to listeners");
            _posts.Add(post);

            return this;
        }
        
        // Unsubscribes listener from the publisher
        public Dispatcher Unsubscribe(int postId, IPost post)
        {
            Console.WriteLine($"Post #{postId} was removed from listeners");
            _posts.Remove(post);

            return this;
        }

        // Sends alert object to every listener
        private void Notify(Alert alert)
        {
            Console.WriteLine($"\nWoop! Woop! That's the sound of da police!\nNotifying all the posts");
            foreach (var post in _posts)
            {
                post.Notify(DispatcherId, alert);
            }
        }

        // Creates the alert object and sends it to the listeners
        public void Inform(string type, string caller, string address, bool isUrgent, string details = null)
        {
            Alert alert = new Alert(type, caller, address, isUrgent, details);
            this.Notify(alert);
        }
    }
}