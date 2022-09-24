using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour{   
    public int VidaCont = 100;
    public Text vida;
    // Start is called before the first frame update
    void Start()
    {
        VidaCont = 100;

    }

    // Update is called once per frame
    void Update()
    {
        vida.text = "Life: " + VidaCont + "%";
    }
}
