using UnityEngine;
using UnityEngine.Events;

namespace ItchyOwl.Propagators
{
    /// <summary>
    /// An implementation of propagating OnDisable callbacks via Unity Events.
    /// </summary>
    public class OnDisablePropagatorU : MonoBehaviour, IMessagePropagatorUnity
    {
        [SerializeField]
        private UnityEvent _disabled = new UnityEvent();
        public UnityEvent Disabled { get { return _disabled; } }

        private void OnDisable()
        {
            if (Disabled != null)
            {
                Disabled.Invoke();
            }
        }
    }
}
