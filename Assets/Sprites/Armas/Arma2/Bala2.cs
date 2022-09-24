using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
        void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Piedra") || collision.CompareTag("Claca") || collision.CompareTag("Enemy1")|| collision.CompareTag("Spawn"))
        { 
     
        GameObject effect = Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(effect,.5f);
        Destroy(gameObject);
        }
    }
    void OnCollision2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            
        GameObject effect = Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(effect,.5f);
        Destroy(gameObject);
        }
        else
        {
       
        }
    }
    
}
