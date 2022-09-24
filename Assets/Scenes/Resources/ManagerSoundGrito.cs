using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSoundGrito : MonoBehaviour
{   
    public static AudioClip sonidogrito;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

        sonidogrito = Resources.Load<AudioClip>("grito");

        audioSource = GetComponent<AudioSource>();
    }

     public static void playSounds(string clip){
        switch(clip){
            case "grito":
            audioSource.PlayOneShot(sonidogrito);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
