using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaBoss : MonoBehaviour
{
    public  static int vidaBoss ;
    public Image barraVida;
    public GameObject explosion;  
    public GameObject portalFinal;

    public GameObject explosionFinal;

    // Start is called before the first frame update
    void Start()
    {
        vidaBoss = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
        barraVida.fillAmount = (float)vidaBoss/100;
        if(VidaBoss.vidaBoss <=0){
            
            Destroy(this.gameObject);
            GameObject final = Instantiate(explosionFinal,transform.position,Quaternion.identity);
            Destroy(final,.8f);
            ManagerSoundExplosion.playSounds("explosionfinal");
            ManagerSoundGrito.playSounds("grito");
            portalFinal.SetActive(true);
            

            //PONER SONIDO DE DESTRUCCION O VICTORIA
        }
    }

    void OnTriggerEnter2D(Collider2D c){
        if(c.CompareTag("Bala1") | c.CompareTag("Bala2")){
            vidaBoss--;
            Destroy(c.gameObject);
            GameObject effect = Instantiate(explosion,c.transform.position,Quaternion.identity);
            Destroy(effect,.5f);
        }
        if (c.CompareTag("Acido"))
        {
            bajarVidaBoss();    

        }
        
    }

    void bajarVidaBoss(){
        vidaBoss -= 10;
    }
}
