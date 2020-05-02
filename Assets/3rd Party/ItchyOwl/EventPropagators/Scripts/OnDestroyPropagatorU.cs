using UnityEngine;
using UnityEngine.Events;

namespace ItchyOwl.Propagators
{
    /// <summary>
    /// An implementation of propagating OnDestroy callbacks via Unity Events.
    /// </summary>
    public class OnDestroyPropagatorU : MonoBehaviour, IMessagePropagatorUnity
    {
        [SerializeField]
        private UnityEvent _destroyed = new UnityEvent();
        public UnityEvent Destroyed { get { return _destroyed; } }

        private void OnDestroy()
        {
            if (Destroyed != null)
            {
                Destroyed.Invoke();
            }
        }
    }
}
