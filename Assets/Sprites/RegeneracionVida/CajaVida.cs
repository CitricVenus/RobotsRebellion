using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaVida : MonoBehaviour
{
    public GameObject vida;
    // Start is called before the first frame update
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
            GameObject vidaprefab = Instantiate(vida,collision.transform.position,Quaternion.identity);
        }
    }
}
