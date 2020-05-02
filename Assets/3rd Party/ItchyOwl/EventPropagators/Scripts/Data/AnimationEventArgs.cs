using System;

namespace ItchyOwl.Propagators
{
    public class AnimationEventArgs : EventArgs
    {
        public readonly string eventName;

        public AnimationEventArgs(string eventName)
        {
            this.eventName = eventName;
        }
    }
}