using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] float ySensitivity = 5f;

    void Update()
    {
        transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * ySensitivity, 0);
    }
}
