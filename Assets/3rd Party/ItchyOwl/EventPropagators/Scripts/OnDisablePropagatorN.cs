using UnityEngine;
using System;

namespace ItchyOwl.Propagators
{
    /// <summary>
    /// An implementation of propagating OnDisable callbacks via native C# events.
    /// </summary>
    public class OnDisablePropagatorN : MonoBehaviour, IMessagePropagatorNative
    {
        public event EventHandler Disabled;

        private void OnDisable()
        {
            if (Disabled != null)
            {
                Disabled(this, EventArgs.Empty);
            }
        }
    }
}
