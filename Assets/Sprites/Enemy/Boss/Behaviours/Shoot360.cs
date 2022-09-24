using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot360 : MonoBehaviour
{
    public GameObject balaPrefab; //Este prefab debe tener un RigidBody2D
    public Transform center;//Un gameobject de referencia que esté en el centro del personaje que sacará las balas.
    private int numBalas;
    private int speed;
    private Librero librero;

    // Start is called before the first frame update
    void Start()
    {       
        librero = Librero.Instance;
        this.balaPrefab = librero.fuegoBala;
        this.center = librero.center;
        this.numBalas = 12;
        this.speed = 13;

        for(int i=0;i<librero.gemas.Length;i++){ //Hacer que las gemas dejen de parpadear.
            librero.gemas[i].SetTrigger("idle");
        }

        StartCoroutine(dispara());
    }

    IEnumerator dispara(){
        int modulo = 0;
        while(true){
            for(int i=1;i<numBalas+1;i++){
                GameObject bullet = Instantiate(balaPrefab,center.position, Quaternion.identity);
                bullet.transform.Rotate(0,0,(360*i/numBalas)+modulo%30);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * speed;
                Destroy(bullet,2f);
            }
            modulo+=15;
            yield return new WaitForSeconds(1f);
        }
    }
}
