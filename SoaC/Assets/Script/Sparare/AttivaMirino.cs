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
        if(arma1.equipped || arma2.equipped || arma3.equipped || arma4.equipped)
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

        if (arma1.equipped || arma2.equipped || arma3.equipped || arma4.equipped)
        {
            GetComponent<LineRenderer>().enabled= true;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }

        
    }
}
