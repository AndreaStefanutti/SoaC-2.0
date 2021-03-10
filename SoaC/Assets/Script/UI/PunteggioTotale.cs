using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PunteggioTotale : MonoBehaviour
{
    public GameObject Player;
    float somma;
  
     Text score;
    // Start is called before the first frame update
    void Start()
    {
        somma= Score.Punteggio + (Player.GetComponent<Timer>().tempoTrascorso) / 6;
        score = GetComponent<Text>();
        score.text = "Score: " + somma;
    }

    // Update is called once per frame
   /* void Update()
    {

        // score.text = "Score: " + Score.Punteggio + (Player.GetComponent<Timer>().tempoTrascorso)/6 ;
        score.text = "Score: " + somma;
    }*/
}
