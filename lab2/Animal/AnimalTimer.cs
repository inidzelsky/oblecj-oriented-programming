using System;
using System.Runtime.Remoting.Channels;
using System.Timers;

namespace Animal
{
    //Class implements timers of hunger and feeding
    public class AnimalTimer
    {
        //Timer activates when animal gets hungry
        private Timer _hungryTimer;

        //Timer prints alert messages
        private Timer _alertTimer;
        private bool _alertTimerActivated;

        //Timer feeds animal
        private Timer _feedTimer;
        private bool _feedTimerActivated;
        
        
        public void SetHungryTimer(Animal animal)
        {
            if (_alertTimer != null)
            {
                _alertTimer.Dispose();
                _alertTimer = null;
            }
            
            _alertTimerActivated = false;

            _hungryTimer = new Timer(animal.FeedTimeOut * 1000);

            // _hungryTimer invokes callback with _alertTimer
            _hungryTimer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                _alertTimer = new Timer(3000);
                
                // _alertTimer prints alert messages with interval
                _alertTimer.Elapsed += (object insideSender, ElapsedEventArgs insideE) =>
                {
                    Console.WriteLine($"{animal.View} is hungry!");
                };

                _alertTimer.AutoReset = true;
                _alertTimer.Enabled = true;
                _alertTimerActivated = true;
            };

            _hungryTimer.AutoReset = false;
            _hungryTimer.Enabled = true;
        }

        //Disposes _hungryTimer and _alertTimer
        public void SetFeedTimer(Animal animal)
        {
            _feedTimer?.Dispose();
            _alertTimer?.Dispose();
            _alertTimer = null;
            
            _feedTimer = new Timer(animal.FeedTimeOut * 1000);
            _feedTimer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                Console.WriteLine($"{animal.View} was fed");
            };

            _feedTimer.AutoReset = true;
            _feedTimer.Enabled = true;
            _feedTimerActivated = true;
        }

        //Pauses _alertTimer during the info enter
        public void SwitchAlertTimer()
        {
            if (_alertTimer == null)
                return;
            
            if (_alertTimerActivated)
                _alertTimer.Stop();
            else
                _alertTimer.Start();

            _alertTimerActivated = !_alertTimerActivated;
        }

        //Pauses _feedTimer during the info enter
        public void SwitchFeedTimer()
        {
            if (_feedTimer == null)
                return;
            
            if (_feedTimerActivated)
                _feedTimer.Stop();
            else
                _feedTimer.Start();

            _feedTimerActivated = !_feedTimerActivated;
        }
    }
}