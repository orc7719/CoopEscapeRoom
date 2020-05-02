using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SingletonExtensions
{
    public static T GetSingleton<T>(this T instance, GameObject prefab) where T : MonoBehaviour
    {
        instance = GetInstance(instance);
        if(instance == null)
        {
            var go = Object.Instantiate(prefab);
            instance = go.GetOrAddComponent<T>(seekChildren: true);
            Debug.LogFormat("[SingletonExtensions] Cannot find an instance of {0}. An instance created {1}", instance.GetType().ToString(), go.name);
        }
        return instance;
    }

    public static T GetSingleton<T>(this T instance, string name) where T : MonoBehaviour
    {
        instance = GetInstance(instance);
        if(instance == null)
        {
            instance = new GameObject(name).AddComponent<T>();
            Debug.LogFormat("[SingletonExtensions] Couldn't find an instance of {0}. An instance created under {1}", instance.GetType().ToString(), instance.name);
        }
        return instance;
    }

    private static T GetInstance<T>(T instance) where T : MonoBehaviour
    {
        if(instance == null)
        {
            var instances = Object.FindObjectsOfType<T>();
            instance = instances.FirstOrDefault();
            if(instance != null)
            {
                Debug.LogFormat("[SingletonExtensions] Instance of {0} found in the scene from the object {1}.", instance.GetType().ToString(), instance.name);
            }
            if(instances.Multiple())
            {
                Debug.LogWarningFormat("[SingletonExtensions] Multiple instances of {0} found!", instance.GetType().ToString());
            }
        }
        return instance;
    }
}
