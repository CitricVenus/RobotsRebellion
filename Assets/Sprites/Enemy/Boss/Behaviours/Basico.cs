using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basico : MonoBehaviour
{
    private Librero librero;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        librero = Librero.Instance;
        target = GameObject.Find("Player").transform;
        StartCoroutine(disparar());
    }

    IEnumerator disparar(){
        while(true){
            librero.center.LookAt(target);
            GameObject bullet = Instantiate(librero.fuegoBala,librero.center.position,Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = librero.center.forward* 10f;
            Destroy(bullet,3f);
            yield  return new WaitForSeconds(1f);
        }
    }
}
