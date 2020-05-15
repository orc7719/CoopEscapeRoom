using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeTrigger : MonoBehaviour
{
    [Scene]
    [SerializeField] string nextScene;

    bool isLoading = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isLoading)
            return;

        if(other.tag == "Player")
        {
            if(other.GetComponent<Player>().isLocalPlayer)
                SceneLoader.Instance.LoadGameScene(nextScene);
        }
    }
}
