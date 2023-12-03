using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMario : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CameraPosition = transform.position;
        CameraPosition.x = player.transform.position.x;
        transform.position = CameraPosition;
    }
}
