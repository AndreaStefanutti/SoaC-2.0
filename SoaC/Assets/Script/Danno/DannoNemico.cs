using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DannoNemico : MonoBehaviour
{
    public float vita=100;
    public void Update()
    {
        if (vita <= 0)
        {
            Destroy(gameObject);
            Debug.Log("E morto");
        }
    }
    public void getDanno(float danno)
    {
        vita = vita - danno;
    }
}
