using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTA: este script se de poner a un prefab, el cual debe ser otro distinto al enemigo, para que sean independientes.
public class EnemyDoble : MonoBehaviour
{
    private Transform target; //Se debe especificar el nombre del target desde el código.
    public GameObject firePoint;
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        StartCoroutine(disparar());
    }

    
     IEnumerator disparar(){
        while(true){
            firePoint.transform.LookAt(target.position);
            GameObject bullet = Instantiate(bulletPrefab,firePoint.transform.position,Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = firePoint.transform.forward* 7.5f;
            Destroy(bullet,3f);
            yield  return new WaitForSeconds(1.0f);
        }
    }
}
