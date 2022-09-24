﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int scene;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            SceneManager.LoadScene(scene);
            
        }
    }
}
