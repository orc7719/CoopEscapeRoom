using UnityEngine;

namespace ItchyOwl.Propagators
{
    /// <summary>
    /// This script forwards the events defined in the animation clips.
    /// The script should be attached to the same transform as the Animator component.
    /// In the "Function" field, type "AnimationEvent".
    /// Unity's animation events apparently use SendMessage under the hood. This means that we can only have one parameter. That's why I'm disregarding the float and int alltogether.
    /// SendMessage invokes all functions by name, which means that the animation event will launch for all the scripts fulfilling the signature AnimationEvent(string eventName).
    /// </summary>
    public class AnimationEventPropagatorU : MonoBehaviour, IMessagePropagatorUnity
    {
        [SerializeField]
        private AnimationEvent _animationEventLaunched = new AnimationEvent();
        public AnimationEvent AnimationEventLaunched { get { return _animationEventLaunched; } }

        public void AnimationEvent(string eventName)
        {
            //Debug.LogFormat("[AnimationEventPropagatorU] {0}, Animation event: {1}", name, eventName);
            if (AnimationEventLaunched != null)
            {
                AnimationEventLaunched.Invoke(eventName);
            }
        }
    }
}

