using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static string debugTag = string.Format("[Singletone {0}]", typeof(T).ToString());

    protected static T _instance;
    public static T Instance
    {
        get
        {
            if(isQuitting) { return _instance; }
            _instance = _instance.GetSingleton(typeof(T).ToString());
            return _instance;
        }
    }

    public static TDerivate GetInstance<TDerivate>() where TDerivate : T
    {
        var i = _instance as TDerivate;
        if(isQuitting) { return i; }
        string derivateTypeName = typeof(TDerivate).ToString();
        i = i.GetSingleton(derivateTypeName);
        if(_instance != null && i != _instance)
        {
            Debug.LogFormat("{0} Upgrading the old instance to {1}", debugTag, derivateTypeName);
            i.CopyValues(_instance);
            Debug.LogFormat("{0} destroying the old instance of type {1}", debugTag, derivateTypeName);
            Destroy(_instance.gameObject);
        }
        _instance = i;
        return i;
    }

    protected static bool isQuitting;
    protected virtual void OnApplicationQuit()
    {
        isQuitting = true;
    }

    protected virtual void OnDestroy()
    {
        if(isQuitting) { return; }
        if(_instance == this)
        {
            _instance = null;
        }
    }

    protected virtual void Awake() { }

    protected virtual void Start()
    {
        if(IsDuplicate(this))
        {
            Debug.LogWarningFormat("[Singleton {0}] Another instance already found! Destroying self as a duplicate.", typeof(T).ToString());
            Destroy(this);
        }
    }

    protected static bool IsDuplicate(Singleton<T> instance)
    {
        if(instance == null) { return false; }
        if(_instance == null) { return false; }
        return _instance != instance;
    }
}
