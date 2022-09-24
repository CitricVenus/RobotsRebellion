using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AppearText : MonoBehaviour
{
    public TextMeshProUGUI texto;
    private float alpha = 0;

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(alpha<=255){
            texto.color = new Color(texto.color.r,texto.color.g,texto.color.b,alpha);
            alpha = alpha+0.0025f;
        }
    }
}
