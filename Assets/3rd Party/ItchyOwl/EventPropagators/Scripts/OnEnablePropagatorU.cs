using UnityEngine;
using UnityEngine.Events;

namespace ItchyOwl.Propagators
{
    /// <summary>
    /// An implementation of propagating OnEnable callbacks via Unity Events.
    /// </summary>
    public class OnEnablePropagatorU : MonoBehaviour, IMessagePropagatorUnity
    {
        [SerializeField]
        private UnityEvent _enabled = new UnityEvent();
        public UnityEvent Enabled { get { return _enabled; } }

        private void OnEnable()
        {
            if (Enabled != null)
            {
                Enabled.Invoke();
            }
        }
    }
}
