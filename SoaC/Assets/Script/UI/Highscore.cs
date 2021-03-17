using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Highscore : MonoBehaviour
{
    public TMP_Text punteggio;
    void Start()
    {
        punteggio.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }
}