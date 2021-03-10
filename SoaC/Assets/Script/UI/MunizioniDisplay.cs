using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MunizioniDisplay : MonoBehaviour
{
    public GameObject arma1;
    public GameObject arma2;
    public GameObject arma3;
    public GameObject arma4;
    public Text textValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (arma1.GetComponent<TPSShooter>().equiped == true)
        {
            textValue.text = arma1.GetComponent<TPSShooter>().munizioniCorrenti.ToString();
        }
        if (arma2.GetComponent<TPSShooter>().equiped == true)
        {
            textValue.text = arma2.GetComponent<TPSShooter>().munizioniCorrenti.ToString();
        }
        if (arma3.GetComponent<TPSShooter>().equiped == true)
        {
            textValue.text = arma3.GetComponent<TPSShooter>().munizioniCorrenti.ToString();
        }
        if (arma4.GetComponent<TPSShooter>().equiped == true)
        {
            textValue.text = arma4.GetComponent<TPSShooter>().munizioniCorrenti.ToString();
        }
    }
}
