using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public Transform target;
    public GameObject pausa;
    public bool isStopped;
    
    // Use this for initialization
    void Start()
    {
        isStopped=pausa.GetComponent<PauseMenu>().isStopped;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isStopped = pausa.GetComponent<PauseMenu>().isStopped;
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
        if (!isStopped)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed / 50);
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance < 1)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("attack", true);
            }
            else
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("attack", false);
            }
        }
    }
}