using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGift : MonoBehaviour
{
    public GameObject gift;
    public GameObject gift2;
    public GameObject block;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            int i = Random.Range(0, 2);
            if (i == 0)
            {
                Instantiate(gift, new Vector2(other.transform.position.x, other.transform.position.y + 3),Quaternion.identity);
            }
            else
            {
                Instantiate(gift2, new Vector2(other.transform.position.x, other.transform.position.y + 3), Quaternion.identity);
            }
            Instantiate(block, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            Destroy(gameObject);
            
        }
    }

}
