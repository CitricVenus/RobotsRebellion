using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuatroFuegos : MonoBehaviour
{
    public GameObject fuegoPrefab;
    private GameObject[] fuegos;
    private int speed;
    public Transform center;
    private Librero librero;
    private int vidaFija;

    // Start is called before the first frame update
    void Start()
    {
        librero = Librero.Instance;
        this.fuegoPrefab = librero.fuegoGrande;
        this.center = librero.center;

        for(int i=0;i<librero.gemas.Length;i++){ //Hacer que las gemas comiencen a parpadear.
            librero.gemas[i].SetTrigger("parpadeo");
        }

        BossScript.active = false; //Make the boss stop
        vidaFija = VidaBoss.vidaBoss;
        StartCoroutine(desvanecer()); // Make the boss disappear

        //this.gema1.SetTrigger("parpadeo");
        
        fuegos = new GameObject[4];
        speed = 9;
        //StartCoroutine(dispara());
        
    }

    IEnumerator desvanecer(){
        //El rgb del boss
        float r = gameObject.GetComponent<Renderer> ().material.color.r;
        float g = gameObject.GetComponent<Renderer> ().material.color.g;
        float b = gameObject.GetComponent<Renderer> ().material.color.b;
        //Ahora, el rgb de la barra de vida
        float rv = librero.barra.color.r;
        float gv = librero.barra.color.g;
        float bv = librero.barra.color.b;
        //La opacidad a controlar
        float a = 1f;
        //Desvanecer
        for(int i=0;i<25;i++){
            a-= 0.04f;
            gameObject.GetComponent<Renderer> ().material.color = new Color(r,g,b,a);
            librero.barra.color = new Color(rv,gv,bv,a);
            VidaBoss.vidaBoss = vidaFija; //Mantener la vida fija mientras se teletransporta.
            yield return new WaitForSeconds(0.08f);
        }
        this.gameObject.transform.position = new Vector3(0.04f,1.21f,0); //Move boss to base
        librero.animBoss.SetTrigger("parar");
        StartCoroutine(appear()); //Make the boss appear.
    }

    IEnumerator appear(){
        //El rgb del boss
        float r = gameObject.GetComponent<Renderer> ().material.color.r;
        float g = gameObject.GetComponent<Renderer> ().material.color.g;
        float b = gameObject.GetComponent<Renderer> ().material.color.b;
        //El rgb de la barra de vida
        float rv = librero.barra.color.r;
        float gv = librero.barra.color.g;
        float bv = librero.barra.color.b;
        //La opacidad a controlar
        float a = 0f;
        for(int i=0;i<25;i++){
            a+= 0.04f;
            gameObject.GetComponent<Renderer> ().material.color = new Color(r,g,b,a);
            librero.barra.color = new Color(rv,gv,bv,a);
            VidaBoss.vidaBoss = vidaFija; //Mantener la vida fija mientras se teletransporta.
            yield return new WaitForSeconds(0.1f);
        }

        for(int i=0;i<librero.gemas.Length;i++){ //Hacer que las gemas dejen de parpadear.
            librero.gemas[i].SetTrigger("idle");
        }

        StartCoroutine(dispara());
    }

    /*void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(dispara());
        }
    }*/

    IEnumerator dispara(){
        int aumento = 0;
        while(true){
            for(int i=0;i<4;i++){
            fuegos[i] = Instantiate(fuegoPrefab,center.position, Quaternion.identity);
            fuegos[i].transform.Rotate(0,0,(360*(i+1)/4)+aumento%90);
            fuegos[i].GetComponent<Rigidbody2D>().velocity = -fuegos[i].transform.up * speed;
            ManagerAudioBoss.playSounds("fuego");
            Destroy(fuegos[i],3f);
            }
            aumento+=30;
            yield return new WaitForSeconds(0.8f);
        }
        
        
    }
}
