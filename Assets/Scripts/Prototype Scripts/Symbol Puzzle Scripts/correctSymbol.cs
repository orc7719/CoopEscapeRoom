using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correctSymbol : MonoBehaviour
{

    GameObject getCorrectTile;

    // Start is called before the first frame update
    void Start()
    {
        getCorrectTile = GameObject.FindGameObjectWithTag("correctTile");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject spawnCorrectTile = Instantiate(getCorrectTile, transform.position, transform.rotation);

        Destroy(gameObject);

        Debug.Log("Symbol Puzzle Completed");
    }
}
