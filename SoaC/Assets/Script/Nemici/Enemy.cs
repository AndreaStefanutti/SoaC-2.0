using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public Transform target;
    public GameObject pauseMenu;
    public PauseMenu tmp; 

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        tmp = pauseMenu.GetComponent<PauseMenu>();

    }


    void Update()
    {
        
       
        if (!tmp.notPaused)
        {
            transform.rotation = Quaternion.LookRotation(target.position - transform.position);

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