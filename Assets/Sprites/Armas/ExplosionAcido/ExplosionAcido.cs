using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAcido : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject acidoExplosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Bala1")){
            Destroy(gameObject);
            GameObject explosion = Instantiate(acidoExplosion,transform.position,Quaternion.identity);
            Destroy(explosion,.8f);
        }
    }
}
