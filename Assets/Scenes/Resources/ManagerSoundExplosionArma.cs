using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSoundExplosionArma : MonoBehaviour
{
    public static AudioClip pared;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        pared = Resources.Load<AudioClip>("pared");
        audioSource = GetComponent<AudioSource>();
    }
     public static void playSounds(string clip){
        switch(clip){
            case "pared":
            audioSource.PlayOneShot(pared);
            break;
            }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
