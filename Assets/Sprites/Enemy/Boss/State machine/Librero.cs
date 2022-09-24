using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Librero : MonoBehaviour
{
    public static Librero Instance{
        get;
        private set;
    }

    public void Awake(){
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject fuegoBala;
    public Transform center;
    public Transform bocaPoint;
    public GameObject fuegoGrande;
    public GameObject enemyToClone;
    public Animator[] gemas;
    public Image barra;

    public Animator animBoss;

}
