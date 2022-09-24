using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAudioBoss : MonoBehaviour
{
    public static AudioClip sonidoFuego,sonidoexplosionfinal;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        sonidoFuego = Resources.Load<AudioClip>("fuego");
        sonidoexplosionfinal = Resources.Load<AudioClip>("explosionfinal");

        audioSource = GetComponent<AudioSource>();
    }

     public static void playSounds(string clip){
        switch(clip){
            case "fuego":
            audioSource.PlayOneShot(sonidoFuego);
            break;
            case "explosionfinal":
            audioSource.PlayOneShot(sonidoexplosionfinal);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
