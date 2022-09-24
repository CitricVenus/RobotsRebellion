using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBox : MonoBehaviour
{
    int vida = 6;
    public GameObject explosion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida == 0)
        {
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect, .5f);
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D c){ 
        if (c.CompareTag("Bala1"))
        {
            vida--;
            
        }
    }
}
