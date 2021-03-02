using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGameOver : MonoBehaviour
    
{
    public GameObject PanelloOn;
    public GameObject Player;
    int PanelVita;
    public float TempoMorte;
    /*public void Awake() 
    {
        //PanelVita = Player.GetComponent<DannoPlayer>().Vita;
       //PanelloOn.SetActive(false);
    }*/
    public void Update()
    {
        PanelVita = Player.GetComponent<DannoPlayer>().Vita;
        if (PanelVita <= 0)
        {
            StartCoroutine(wait());
            
            
            PanelloOn.SetActive(true);
            
            //Time.timeScale = 0f;

        }
           
    }
    IEnumerator wait()
    {
       
        yield return new WaitForSeconds(TempoMorte);
        


    }
}
