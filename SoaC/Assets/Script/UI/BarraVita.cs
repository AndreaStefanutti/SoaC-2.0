using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVita : MonoBehaviour
{
    public Image barra;
    //public float MaxVita = 100;
    //float Barravita;
    public GameObject PlayerVita;

    // Start is called before the first frame update
    void Start()
    {

       // Barravita = GetComponent<DannoNemico>().vita;
    }

    // Update is called once per frame
    void Update()
    {
        barra.fillAmount = GetComponent<DannoNemico>().vita / 100;
    }
}
