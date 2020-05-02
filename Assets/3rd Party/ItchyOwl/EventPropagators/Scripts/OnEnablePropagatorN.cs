using UnityEngine;
using System;

namespace ItchyOwl.Propagators
{
    /// <summary>
    /// An implementation of propagating OnEnable callbacks via native C# events.
    /// </summary>
    public class OnEnablePropagatorN : MonoBehaviour, IMessagePropagatorNative
    {
        public event EventHandler Enabled;

        private void OnEnable()
        {
            if (Enabled != null)
            {
                Enabled(this, EventArgs.Empty);
            }
        }
    }
}
