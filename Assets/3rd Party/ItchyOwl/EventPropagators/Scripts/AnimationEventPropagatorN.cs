using UnityEngine;
using System;

namespace ItchyOwl.Propagators
{
    /// <summary>
    /// This script forwards the events defined in the animation clips.
    /// The script should be attached to the same transform as the Animator component.
    /// In the "Function" field, type "AnimationEvent" or "GlobalAnimationEvent".
    /// Unity's animation events apparently use SendMessage under the hood. This means that we can only have one parameter. That's why I'm disregarding the float and int alltogether.
    /// SendMessage invokes all functions by name, which means that the animation event will launch for all the scripts fulfilling the signature AnimationEvent(string eventName).
    /// </summary>
    public class AnimationEventPropagatorN : MonoBehaviour, IMessagePropagatorNative
    {
        public event Action<string> AnimationEventLaunched;
        public static event EventHandler<AnimationEventArgs> GlobalAnimationEventLaunched;

        public void AnimationEvent(string eventName)
        {
            //Debug.LogFormat("[AnimationEventPropagatorN] {0}, Animation event: {1}", name, eventName);
            if (AnimationEventLaunched != null)
            {
                AnimationEventLaunched(eventName);
            }
        }

        public void GlobalAnimationEvent(string eventName)
        {
            //Debug.LogFormat("[AnimationEventPropagatorN] {0}, Global animation event: {1}", name, eventName);
            if (GlobalAnimationEventLaunched != null)
            {
                GlobalAnimationEventLaunched(this, new AnimationEventArgs(eventName));
            }
        }
    }
}

