using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIdaPlayer : MonoBehaviour
{
    public static int vida;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        vida = 100;
    }
}
