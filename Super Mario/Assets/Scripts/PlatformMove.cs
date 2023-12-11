using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector2 start;
    public Vector2 end;
    private bool temp = true;
    private Transform oldParent;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = start;

    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (temp)
        {
            transform.position = Vector2.MoveTowards(transform.position, end, step);
            float dist = Vector2.Distance(transform.position, end);
            if (dist < 0.001f)
            {
                temp = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, start, step);
            float dist = Vector2.Distance(transform.position, start);
            if (dist < 0.001f)
            {
                temp = true;
            }
        }
    }
}
