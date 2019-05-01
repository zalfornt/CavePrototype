using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;

    private float offsetZ = -10f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + new Vector3(0, 0, offsetZ);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 0, offsetZ);
    }
}
