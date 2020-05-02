v.1.1

Thank you for testing Event Propagators!

Event Propagators is a simple solution for forwarding Unity callbacks to be used by other components. The purpose of this is to support better decoupling of your components. It allows you to handle the callback in one place and react to them in another place.

If you are new to Unity Events or the native C# events or there is something you don't understand, please read through my article on events at https://itchyowl.com/events-in-unity/

All the scripts can be found in ItchyOwl/EventPropagators/Scripts/ folder. In the Scripts root, there are event propagators for OnDestroy, OnDisable, and OnEnable messages. Consider these as examples. Feel free to implement your own propagators in the model of these three. AnimationEventPropagators are two scripts for forwarding the animation events further. Have a look at the script summaries for further details.

Change Log
----------
1.1 Add AnimationEventPropagatorN and AnimationEventPropagatorU. Refactor abstract MessagePropagator classes into interfaces.
1.0 Initial release.