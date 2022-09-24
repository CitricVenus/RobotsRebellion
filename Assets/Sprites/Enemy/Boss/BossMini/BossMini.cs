﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMini : MonoBehaviour
{
    private float speed;
    private Transform target;
     public Animator animator;
     public     Rigidbody2D rb;
     Vector2 movement;
     Vector3 dir;
     public GameObject bones;
     float vida;
     Player playerScript;
    public  static bool active;
    public GameObject explosion;
 
    // Start is called before the first frame update
    public void Start()
    {
        vida = 3;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }


    // Update is called once per frame
    public void Update()
    {
        if(active){
            if(Vector2.Distance(transform.position,target.position)>=1.5){
                speed = 1f;
                movement = (target.transform.position-transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
                animator.SetFloat("x",movement.x);
                animator.SetFloat("y",movement.y);
                animator.SetFloat("Speed",movement.sqrMagnitude);
                animator.SetBool("stop",false);
        } 
 
            if(Vector2.Distance(transform.position,target.position) <= 1.5f){
            animator.SetBool("stop",true);
            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
  
    }
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala1"))
        {   Destroy(collision.gameObject);
            GameObject effect = Instantiate(explosion,collision.transform.position,Quaternion.identity);
            Destroy(effect,.5f);
            if(active)
                vida -=1;   
            if (vida<=0){
                ManagerSounScript.playSounds("grunido");
                Destroy(gameObject);
                GameObject death = Instantiate(bones,transform.position,Quaternion.identity);
                Destroy(death,6f);
                Machine.vencidos ++;
            }
        }
        if (collision.CompareTag("Bala2"))
        {
            Destroy(collision.gameObject);
            GameObject effect = Instantiate(explosion,collision.transform.position,Quaternion.identity);
            Destroy(effect,.5f);
            if(active)
                vida -=12;
            if (vida<=0){
                ManagerSounScript.playSounds("grunido");
                Destroy(gameObject);
                GameObject death = Instantiate(bones,transform.position,Quaternion.identity);
                Destroy(death,6f);
                Machine.vencidos ++;
            }
        }
        if (collision.CompareTag("BarrilAcido")){
            vida = vida-15;
        }
    }
}
