using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttivaMirino : MonoBehaviour
{
    public PickUpController arma1;
    public PickUpController arma2;
    public PickUpController arma3;
    public PickUpController arma4;

    //public bool attiva;
    
    //public GameObject a;
    LineRenderer mira;


    void Start()
    {
        if(arma1.slotFull || arma2.slotFull || arma3.slotFull || arma4.slotFull)
        {
            //attiva = true;
           GetComponent<LineRenderer>().enabled = true; 
           
           
            
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }

       //mira = a.GetComponent<LineRenderer>();
        //mira.enabled(attiva);
        
        //a = GameObject<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (arma1.slotFull || arma2.slotFull || arma3.slotFull || arma4.slotFull)
        {
            GetComponent<LineRenderer>().enabled= true;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }

        
    }
}
