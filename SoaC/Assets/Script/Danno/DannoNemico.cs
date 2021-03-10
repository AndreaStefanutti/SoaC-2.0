using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DannoNemico : MonoBehaviour
{
    public float TempoMorte;
    public float vita = 100;
    public Animator anim;
    public GameObject omino;
    void Start()
    {
       
        anim = GetComponent<Animator>();
        anim.SetBool("Death", false);

    }

    public void Update()
    {
        if (vita <= 0)
        {
            StartCoroutine(wait());
        }
    }
      public void getDanno(float danno)
        {
            vita = vita - danno;
        }
    
        IEnumerator wait()
        {
        GetComponent<Enemy>().speed = 0f;
        anim.SetBool("Death", true);
        yield return new WaitForSeconds(TempoMorte);

            Destroy(gameObject);
            Debug.Log("E morto");



        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mazza" && omino.GetComponent<MyPlayer>().mazzata)
        {
            vita = 0;
        }
    }


}
