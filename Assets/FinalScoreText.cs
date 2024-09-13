using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreText : MonoBehaviour
{
    public Text text;
    void Start()
    {
        float finalTime = PlayerPrefs.GetFloat("FinalTime", 0);
        text.text = "YOU USED:\n" + finalTime.ToString("F2") + " s!";
    }


}
