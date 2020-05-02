using UnityEngine;
using System;

namespace ItchyOwl.Propagators
{
    /// <summary>
    /// An implementation of propagating OnDestroy callbacks via native C# events.
    /// </summary>
    public class OnDestroyPropagatorN : MonoBehaviour, IMessagePropagatorNative
    {
        public event EventHandler Destroyed;

        private void OnDestroy()
        {
            if (Destroyed != null)
            {
                Destroyed(this, EventArgs.Empty);
            }
        }
    }
}
