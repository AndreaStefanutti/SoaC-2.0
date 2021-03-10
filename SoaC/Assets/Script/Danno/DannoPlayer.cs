using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DannoPlayer : MonoBehaviour
{
    public float TempoMorte;
    public float Vita;
    float danno = 20;
    float dannoAcqua = 0.1f;
    public Animator anim;
    public GameObject Controller;
    GameObject Trasform;
    public Image Barra;
    public void Update()
    {
        Barra.fillAmount =(float) Vita / 100;
        if (Vita <= 0)
        {
            anim.SetBool("isDeath", true);
            StartCoroutine(wait());
        }
    }
    private void Start()
    {
        Vita = 100;
        print(Vita);
        anim = GetComponent<Animator>();
        anim.SetBool("isDeath", false);
        //Trasform = GetComponent<MyPlayer>
    }
    private void OnCollisionEnter(Collision collisione)
    {
        if (collisione.gameObject.tag == "Enemy")
        {
            Vita = Vita - danno;
            print("Ecco la vita" + Vita);
            Debug.LogWarning("Ecco la vita" + Vita);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Acqua")
        {
            Vita = Vita - dannoAcqua;
            print("Ecco la vita" + Vita);
            Debug.LogWarning("Ecco la vita" + Vita);
        }
    }
    IEnumerator wait()
    {
        Controller.SetActive(false);
        GetComponent<MyPlayer>().SpeedVelocity = 0f;
        anim.SetBool("Death", true);
        yield return new WaitForSeconds(TempoMorte);

        Destroy(gameObject);
        Debug.Log("E morto");
    }
}
