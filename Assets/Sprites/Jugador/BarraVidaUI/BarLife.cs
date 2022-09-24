using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLife : MonoBehaviour
{
   public Image barLife;
   private int vidaMaxima = 100;
    
    void Update()
    {
        barLife.fillAmount = (float)VIdaPlayer.vida/vidaMaxima;
    }
}
