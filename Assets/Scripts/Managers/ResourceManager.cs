using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Managers/Resource Manager")]
public class ResourceManager : ScriptableSingleton<ResourceManager>
{
    [Serializable]
    public class GameReferences
    {
        [Serializable]
        public class ObjectPrefabs
        {
            public Managers manager;
        }
        [SerializeField]
        private ObjectPrefabs _prefabs = new ObjectPrefabs();
        public ObjectPrefabs Prefabs { get { return _prefabs; } }

    }

    [SerializeField]
    private GameReferences _references = new GameReferences();
    public GameReferences References { get { return _references; } }
}