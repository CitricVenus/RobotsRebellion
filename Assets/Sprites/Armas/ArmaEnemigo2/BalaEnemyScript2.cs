using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemyScript2 : MonoBehaviour
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
     void OnCollisionEnter2D(Collision2D collision){
         if (collision.gameObject.tag == "Piedra")
         {
             GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect, .5f);
             Destroy(gameObject);
         }
     }
    
}
