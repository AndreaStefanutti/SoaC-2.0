using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MunizioniDisplay : MonoBehaviour
{
    public int munizioni;
    public Text textValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textValue.text = munizioni.ToString();
    }
}
