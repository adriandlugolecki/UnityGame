using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMove : MonoBehaviour
{
    private GameManager gameManager;
    private Vector2 position;
    private float speed = 2f;
    private Vector2 target;
    private Vector2 positionZero;

    private bool temp = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        position = gameObject.transform.position;
        positionZero = position;
        target = new Vector2(position.x, position.y + 4);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (!temp)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            float dist = Vector2.Distance(transform.position, target);
            if(dist ==  0)
            {
                temp = true;
            }
        }
        else { 
            transform.position = Vector2.MoveTowards(transform.position, positionZero, step);
            float dist = Vector2.Distance(transform.position, positionZero);
            if (dist == 0)
            {
                temp = false;
            }
            
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            gameManager.TakeAllLife();
        }
    }
}
