using UnityEngine;

namespace ItchyOwl.Propagators.Examples
{
    public class PropagatorExample : MonoBehaviour
    {
        public GameObject sphere;
        public GameObject cube;

        private void Awake()
        {
            sphere.GetComponent<OnEnablePropagatorN>().Enabled += (sender, args) => Debug.Log("Sphere enabled");
            sphere.GetComponent<OnDisablePropagatorN>().Disabled += (sender, args) => Debug.Log("Sphere disabled");
            sphere.GetComponent<OnDestroyPropagatorN>().Destroyed += (sender, args) => Debug.Log("Sphere destroyed");

            cube.GetComponent<OnEnablePropagatorU>().Enabled.AddListener(() => Debug.Log("Cube enabled"));
            cube.GetComponent<OnDisablePropagatorU>().Disabled.AddListener(() => Debug.Log("Cube disabled"));
            cube.GetComponent<OnDestroyPropagatorU>().Destroyed.AddListener(() => Debug.Log("Cube destroyed"));
        }
    }
}
