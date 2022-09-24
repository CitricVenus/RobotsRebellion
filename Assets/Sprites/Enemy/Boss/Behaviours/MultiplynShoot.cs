using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplynShoot : MonoBehaviour
{
    public GameObject enemyToDuplicate;
    public int qtyDobles =4;
    private GameObject[] dobles;
    private Librero librero;

    // Start is called before the first frame update
    void Start()
    {   
        librero = Librero.Instance;
        this.enemyToDuplicate = librero.enemyToClone;

        dobles = new GameObject[qtyDobles];
        for(int i=0;i<qtyDobles;i++){
            dobles[i] = Instantiate(enemyToDuplicate,transform.position,Quaternion.identity);
        }

        StartCoroutine(aumentaVida());
        for(int i=0;i<librero.gemas.Length;i++){ //Hacer que las gemas comiencen a parpadear.
            librero.gemas[i].SetTrigger("parpadeoVida");
        }
        StartCoroutine(divide());
    }

    IEnumerator divide(){
        //Hacer que se separen del boss
        for(int i=0;i<17;i++){
            dobles[0].transform.position = new Vector3(transform.position.x,dobles[0].transform.position.y+0.3f,transform.position.z);
            dobles[1].transform.position = new Vector3(transform.position.x,dobles[1].transform.position.y-0.3f,transform.position.z);
            dobles[2].transform.position = new Vector3(dobles[2].transform.position.x+0.3f,transform.position.y,transform.position.z);
            dobles[3].transform.position = new Vector3(dobles[3].transform.position.x-0.3f,transform.position.y,transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        BossMini.active = true;
        //StartCoroutine(wait());
        //StopCoroutine(divide());
    }

    IEnumerator aumentaVida(){
        while(true){
            VidaBoss.vidaBoss += 1;
            print("aumenta vida");
            yield return new WaitForSeconds(0.5f);
        }
    }

    /*IEnumerator wait(){
        
        yield return new WaitForSeconds(8);
        StartCoroutine(join());
        StopCoroutine(wait());
    }
    IEnumerator join(){
        //Hacer que se junten nuevamente
        for(int i=0;i<17;i++){
            dobles[0].transform.position = new Vector3(transform.position.x,dobles[0].transform.position.y-0.3f,transform.position.z);
            dobles[1].transform.position = new Vector3(transform.position.x,dobles[1].transform.position.y+0.3f,transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        killDobles();
        StopCoroutine(join());
    }

    void killDobles(){
        for(int i=0;i<qtyDobles;i++){
            Destroy(dobles[i]);
        }
    }*/
}
