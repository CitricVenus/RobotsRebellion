using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed  = 5f;
    
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public Text restart;
    bool vivo;
    //["Crosshair objetos"]
    public GameObject crosshair;
    float crosshairdist ;
    //["Arma 1 objetos"]
    public GameObject bulletPrefab;
    bool arma1Active;
    float speed_bullet = 100f;

    //["Arma 2 objetos"]
    public GameObject bullet2Prefab;
    float speed_bullet2 = 100f;
    bool arma2Active;
    int arma2Ammo;
    Vector2 damage;
    IEnumerator disparoRutina;
    public GameObject explosion;
    private bool iniciosonidotierra = false,
                  inicioSonidometal= false;

    private bool once;
    

    void Start()
    {   
        crosshairdist = 1f;
        restart.gameObject.SetActive(false);
        vivo = true;
        arma2Active = false;
        arma1Active = true;
        arma2Ammo =20;
        once = true;
    }

    void Update()
    {
        if(vivo){
            
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal",movement.x);
            animator.SetFloat("Vertical",movement.y);
            animator.SetFloat("Speed",movement.sqrMagnitude);
            Aim();
            Shoot();
        }else{
            SceneManager.LoadScene(3);
        }
         /*if(Input.GetKeyDown(KeyCode.Space)){
            vivo = true;
            vida.VidaCont = 100;
            restart.gameObject.SetActive(false);
         }*/

         if(VIdaPlayer.vida <=0)
            {
                CancelInvoke("bajarVida");
                vivo = false;
                VIdaPlayer.vida = 0;
                //restart.gameObject.SetActive(true);
            }
         
    }
 
    void FixedUpdate()
    {
        if(vivo){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        
        }
    }

    void Aim()
    {   
        if(movement != Vector2.zero){
             crosshair.transform.localPosition = movement * crosshairdist;
        }
    }
    void Shoot()
    {  
        if(arma2Active ==true){
            if(arma2Ammo >0){
                if(Input.GetButtonDown("Fire1") && once){
                    
                    once = false;
                    disparoRutina = disparar(bullet2Prefab, speed_bullet2, true);
                    StartCoroutine(disparoRutina);
                    arma2Ammo -=1;
                }
                if(Input.GetButtonUp("Fire1")){
 
                    StopCoroutine(disparoRutina);
                    once = true;
                }
            }else{

                arma2Active = false;
                StopCoroutine(disparoRutina);
                arma1Active = true;
                once = true;
            }
        }
        if(arma1Active == true){
            if(Input.GetButtonDown("Fire1") && once){
                once = false;
                disparoRutina = disparar(bulletPrefab, speed_bullet, false);
                StartCoroutine(disparoRutina);
            }
            if(Input.GetButtonUp("Fire1")){
                once = true;
                StopCoroutine(disparoRutina);
            }

        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Enemy1")){
            InvokeRepeating("bajarVida",0,0.7f);
            //Vida.VidaCont -= 5;
            //Vector2 difference = transform.position - collision.transform.position;
            //transform.position = new Vector2(transform.position.x +Random.Range(0,2), transform.position.y + Random.Range(0,2));
            
        }
        if (collision.CompareTag("Arma2")){
            ManagerSounScript.playSounds("arma");
            arma2Active = true;
            arma1Active = false;
            
            //Debug.Log("Recoje arma");
        }

        if(collision.tag == "BalaEnemy2"){
            Destroy(collision.gameObject);
            bajarVida();
            GameObject effect = Instantiate(explosion,collision.transform.position,Quaternion.identity);
            Destroy(effect,.5f);
        }
         if (collision.CompareTag("Acido")){
             bajarVidaExplosion();
         }
        if (collision.CompareTag("Vida")){
            ManagerSounScript.playSounds("vida");
             aumentarVida();
         }
        if(collision.tag == "fuego1"){
            Destroy (GameObject.FindWithTag("fuego1"));
            bajarVidaFuegoM();

         }
        if(collision.tag == "fuego2"){
            Destroy (GameObject.FindWithTag("fuego2"));
            bajarVidaFuegoG();

         }
        
    }
    void OnTriggerStay2D(Collider2D collision){

          if (collision.CompareTag("tierra")){
             if(movement.sqrMagnitude > 0){   
              ManagerSoudTierra.tierra = true;
              if (!iniciosonidotierra)
              {
                ManagerSoudTierra.playSounds("tierra1");
                iniciosonidotierra = true;
                //print(movement.sqrMagnitude);
              }
             
              }

            if(movement.sqrMagnitude == 0){
                if (iniciosonidotierra)
                {
                iniciosonidotierra = false;
                ManagerSoudTierra.tierra = false;
                ManagerSoudTierra.playSounds("tierra1");
                //print(movement.sqrMagnitude);
                }
               
            }  
         } 
          if (collision.CompareTag("metal")){
             if(movement.sqrMagnitude > 0){   
              ManagerSoudTierra.metal = true;
              if (!inicioSonidometal)
              {
                ManagerSoudTierra.playSounds("Metal");
                inicioSonidometal = true;
                //print(movement.sqrMagnitude);
              }
             
              }

            if(movement.sqrMagnitude == 0){
                if (inicioSonidometal)
                {
                inicioSonidometal = false;
                ManagerSoudTierra.metal = false;
                ManagerSoudTierra.playSounds("Metal");
                //print(movement.sqrMagnitude);
                }
               
            }  
         } 
           
    }


    void OnTriggerExit2D(Collider2D collision){
        CancelInvoke("bajarVida");

        iniciosonidotierra = false;
        ManagerSoudTierra.tierra = false;
        ManagerSoudTierra.playSounds("tierra1");


        inicioSonidometal = false;
        ManagerSoudTierra.metal = false;
        ManagerSoudTierra.playSounds("Metal");


    }

    void bajarVida(){
        VIdaPlayer.vida -= 5;
    }
    void bajarVidaFuegoM(){
        VIdaPlayer.vida -= 5;
    }
    void bajarVidaFuegoG(){
        VIdaPlayer.vida -= 10;
    }
    void bajarVidaExplosion(){
        VIdaPlayer.vida -= 10;
    }
     void aumentarVida(){
        VIdaPlayer.vida += 25;
    }

    IEnumerator disparar(GameObject bulletPrefab, float speed, bool secondArma){
        while(true){
            Vector2 shootdir = crosshair.transform.localPosition;
            shootdir.Normalize();
            GameObject bullet = Instantiate(bulletPrefab,new Vector2(transform.position.x + shootdir.x, transform.position.y+shootdir.y), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootdir * speed;
            bullet.transform.Rotate(0,0,Mathf.Atan2(shootdir.y,shootdir.x) * Mathf.Rad2Deg);
            Destroy(bullet,2f);
           if(!secondArma){
            ManagerSounScript.playSounds("Bullet1");
           }
            if(secondArma){
            arma2Ammo -=1;
            ManagerSounScript.playSounds("Bullet2");
            }
            yield  return new WaitForSeconds(0.5f);
        }
    }

}
