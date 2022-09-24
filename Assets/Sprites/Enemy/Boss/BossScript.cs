using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private float speed;
    private Transform target;
    public Animator animator;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector3 dir;
    public static bool active;
 
    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        active = true;
        animator.SetBool("stop",false);

        
    }

    // Update is called once per frame
    public void Update()
    {
       if(active){
        if(Vector2.Distance(transform.position,target.position)>=1.5){
                Debug.Log("Hola");
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
        Debug.Log("Anim stop");
         }
        }
        
    }
}
