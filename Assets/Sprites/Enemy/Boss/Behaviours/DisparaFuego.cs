using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparaFuego : MonoBehaviour
{
    public GameObject fuegoBala;
    public Transform bocaPoint;
    private Transform target;
    private GameObject[] fuegos;
    private int numFuegos = 30;
    //private int numDisparos = 30;
    private Vector2 direction;
    private Librero librero;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent("Basico"));

        librero = Librero.Instance;
        this.fuegoBala = librero.fuegoBala;
        this.bocaPoint = librero.bocaPoint;

        fuegos = new GameObject[numFuegos];
        target = GameObject.Find("Player").transform;
        StartCoroutine(apunta());
        
    }

    IEnumerator apunta(){
        while(true){
            direction = (target.position - transform.position).normalized;
            Vector2 boca = new Vector2(bocaPoint.position.x,bocaPoint.position.y);
            StartCoroutine(dispara(direction,boca));
            //metodoPrueba(direction);
            yield return new WaitForSeconds(4f); 
        }
        
    }

    IEnumerator dispara(Vector2 direction,Vector2 boca){
        for(int i=0;i<numFuegos;i++){
            //fuegos[i] = Instantiate(fuegoBala,direction*0.07f*(i+1),bocaPoint.transform.rotation);
            fuegos[i] = Instantiate(fuegoBala,boca+direction*(i+1),bocaPoint.rotation);
            Destroy(fuegos[i],0.4f);
            yield return new WaitForSeconds(0.02f);
        }
        //StartCoroutine(desvanece());
    }
}
