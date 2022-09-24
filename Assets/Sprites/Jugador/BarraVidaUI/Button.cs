using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void GoToScene(int scene){
        SceneManager.LoadScene(scene);
    }

    public void GoToSceneByName(string name){
        SceneManager.LoadScene(name);
    }
}
