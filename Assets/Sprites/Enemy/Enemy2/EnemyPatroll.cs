using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroll : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform [] points;
    public float speed = 5f;
    private int currentTargetIndex;
    Transform currentTargetPoint;
    Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public bool active;
    private Transform player;
    private IEnumerator patrullar;
    private IEnumerator dispara;
    private bool startPatrol;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject bones;
    public  float vida;
    void Start()
    {
        vida = 10;
        currentTargetIndex = 0;
        currentTargetPoint = points[currentTargetIndex];
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        active = true;
        patrullar = avanzar();
        StartCoroutine(patrullar);
        dispara = disparar();
        startPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
           if (Vector2.Distance(transform.position, currentTargetPoint.position) < 0.2f)
            {
                StopCoroutine(patrullar);
                animator.SetBool("Stop",true);
                if(currentTargetIndex + 1 < points.Length){
                    currentTargetIndex ++;
                }
                else{
                    currentTargetIndex = 0;
                }
                currentTargetPoint = points[currentTargetIndex];
                startPatrol = false;
            }
            else if(startPatrol == false){
                StartCoroutine(patrullar);
                startPatrol = true;
            }
        }
        if (vida == 0)
        {
            Destroy(gameObject);
        }
                
    }

    IEnumerator avanzar(){
        while(true){
            movement = (currentTargetPoint.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, points[currentTargetIndex].position,speed * Time.deltaTime);
            this.animator.SetFloat("x",movement.x);
            this.animator.SetFloat("y",movement.y);
            this.animator.SetFloat("Speed",movement.sqrMagnitude);
            animator.SetBool("Stop",false);
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator disparar(){
        while(true){
            firePoint.transform.LookAt(player.position);
            GameObject bullet = Instantiate(bulletPrefab,firePoint.transform.position,Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = firePoint.transform.forward* 5f;
            Destroy(bullet,2f);
            yield  return new WaitForSeconds(1.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D c){
        if(c.tag == "Player"){
            StopCoroutine(patrullar);
            player = c.transform;
            StartCoroutine(dispara);
        }
        /*
        if (c.CompareTag("Bala1") | c.CompareTag("Bala2"))
        {   
            if(c.CompareTag("Bala1"))
                vida-=1;
            if(c.CompareTag("Bala2"))
                vida-=12;
                
            if (vida<=0){
                Destroy(gameObject);
                GameObject death = Instantiate(bones,transform.position,Quaternion.identity);
                Destroy(death,6f);
            }
        }*/
    }
    void OnTriggerExit2D(Collider2D c){
        if(c.tag == "Player"){
            StopCoroutine(dispara);
            //player = null;
            currentTargetPoint = points[currentTargetIndex];
            StartCoroutine(patrullar);
        }
    }

}
