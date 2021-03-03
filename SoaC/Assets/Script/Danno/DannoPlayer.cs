using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DannoPlayer : MonoBehaviour
{
    public float TempoMorte;
    public int Vita;
    int danno = 20;
    public Animator anim;
    public GameObject Controller;
    GameObject Trasform;
    public void Update()
    {
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
