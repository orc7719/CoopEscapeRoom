using ItchyOwl.Propagators;
using UnityEngine;

public static class GameManager
{
    private static string debugTag = "[GameManager]";

    public static GameSettings Settings { get { return GameSettings.Instance; } }
    public static ResourceManager Resources { get { return ResourceManager.Instance; } }

    private static Managers _managers;
    private static Managers Managers
    {
        get
        {
            if(_managers == null)
            {
                if(_managers == null)
                {
                    _managers = Object.FindObjectOfType<Managers>();
                }
                if(_managers != null)
                {
                    Debug.LogFormat("{0} Managers found in the scene.", debugTag);
                }
                else
                {
                    _managers = UnityEngine.Object.Instantiate(Resources.References.Prefabs.manager);
                    Debug.LogFormat("{0} Managers instantiated.", debugTag);
                }
                _managers.gameObject.GetOrAddComponent<OnDestroyPropagatorN>().Destroyed += (sender, args) =>
                {
                    Debug.LogFormat("{0} Managers destroyed.", debugTag);
                    _managers = null;
                };
            }
            return _managers;
        }
    }

    public static void Setup()
    {
        _managers = Managers;
    }
}