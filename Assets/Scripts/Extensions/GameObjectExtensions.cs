using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
    public static T GetOrAddComponent<T>(this GameObject go, bool seekChildren = false) where T : Component
    {
        T component = seekChildren ? go.GetComponentInChildren<T>(includeInactive: true) : go.GetComponent<T>();
        if(component == null)
        {
            component = go.AddComponent<T>();
        }
        return component;
    }
}
