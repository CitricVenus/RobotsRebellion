using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Scorevalue = 0;
    public Text score;
    void Start()
    {
        Scorevalue  = 0;

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + Scorevalue;
    }
}
