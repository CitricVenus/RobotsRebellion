using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSoudTierra : MonoBehaviour
{
    public static AudioClip soundtierra, soundmetal; 
    static AudioSource audioSource;

     public static bool tierra = false,
                        metal = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundtierra = Resources.Load<AudioClip>("tierra1");
        soundmetal = Resources.Load<AudioClip>("Metal");
    }

    public static void playSounds(string clip){
        switch(clip){
         case "tierra1":
            if (tierra == true)
            {
            audioSource.loop=true;
            audioSource.clip = soundtierra;
            audioSource.Play();
            }
            else if(tierra == false){
            audioSource.loop=false;
            audioSource.clip = soundtierra;
            audioSource.Stop();
            }
            break;
            case "Metal":
            if (metal == true)
            {
            audioSource.loop=true;
            audioSource.clip = soundmetal;
            audioSource.Play();
            }
            else if(metal == false){
            audioSource.loop=false;
            audioSource.clip = soundmetal;
            audioSource.Stop();
            }
            break;

        
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
