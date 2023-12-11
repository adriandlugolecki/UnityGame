using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMario : MonoBehaviour
{
    public GameObject player;


    void Update()
    {
        Vector3 CameraPosition = transform.position;
        CameraPosition.x = player.transform.position.x;
        transform.position = CameraPosition;

        
    }
}
