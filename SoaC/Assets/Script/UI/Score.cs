using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static int Punteggio;
     Text score;
    // Start is called before the first frame update
    void Start()
    {
        Punteggio = 0;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + Punteggio;
    }
}
