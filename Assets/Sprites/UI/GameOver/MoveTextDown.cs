using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTextDown : MonoBehaviour
{
    public GameObject texto;
    private float inicioY;
    public float finY;

    void Start(){
        inicioY = texto.transform.position.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(inicioY>=finY){
            inicioY = inicioY-1.3f;
            texto.transform.position = new Vector3(texto.transform.position.x,inicioY,texto.transform.position.z);
        }
    }
}
