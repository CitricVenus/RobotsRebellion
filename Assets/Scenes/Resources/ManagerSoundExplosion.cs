using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSoundExplosion : MonoBehaviour
{
    // Start is called before the first frame update 
    public static AudioClip sonidoexplosion;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

        sonidoexplosion = Resources.Load<AudioClip>("explosionfinal");

        audioSource = GetComponent<AudioSource>();
    }

     public static void playSounds(string clip){
        switch(clip){
            case "explosionfinal":
            audioSource.PlayOneShot(sonidoexplosion);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
