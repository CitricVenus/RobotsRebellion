using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBalas : MonoBehaviour
{  
    public GameObject explosion;   

    public GameObject bones;
    public EnemyPatroll enemy;

    

    void OnTriggerEnter2D(Collider2D c){
          if (c.CompareTag("Bala1") | c.CompareTag("Bala2"))
        {  
             GameObject effect = Instantiate(explosion,c.transform.position,Quaternion.identity);
             Destroy(effect,.5f);
             Destroy(c.gameObject);
            
            if(c.CompareTag("Bala1"))
                enemy.vida-=1;
            if(c.CompareTag("Bala2"))
                enemy.vida-=12;
                
            if (enemy.vida<=0){
                Destroy(gameObject);
                GameObject death = Instantiate(bones,transform.position,Quaternion.identity);
                Destroy(death,6f);
            }
        }
    }
    
}
