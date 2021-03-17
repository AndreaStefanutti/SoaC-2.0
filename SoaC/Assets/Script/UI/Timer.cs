using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public static Timer iniziale;
    public Text Cronometro;
    private TimeSpan tempoCronometro;
    private bool timerBoll;
    public float tempoTrascorso;

    private void Awake()
    {
        iniziale = this;
    }

    
    private void Start()
    {
        Cronometro.text = "tempo : 00:00:00";
        timerBoll = false;


    }

    private void Update()
    {
        tempoTrascorso = tempoTrascorso + Time.deltaTime;
        tempoCronometro = TimeSpan.FromSeconds(tempoTrascorso);
        string tempoCronometratoStr = "tempo:" + tempoCronometro.ToString("mm':'ss':'ff");
        Cronometro.text = tempoCronometratoStr;
    }
    public void InizializzareTempo()
    {
        timerBoll = true;
        //tempoTrascorso = 0f;
       // StartCoroutine(ActUpdate());
    }
    public void TempoFine()
    {
        timerBoll = false;
       
    }
   /* private IEnumerator ActUpdate()
    {
        while(timerBoll)
        {
            tempoTrascorso += Time.deltaTime;

            tempoCronometro = TimeSpan.FromSeconds(tempoTrascorso);
            string tempoCronometratoStr = "Tempo: " + tempoCronometro.ToString("mm':'ss':'ff");
            Cronometro.text = tempoCronometratoStr;
           
            yield return null;
        }
    }*/
}
