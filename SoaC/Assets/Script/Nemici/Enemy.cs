﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public Transform target;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
       
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        float distance = Vector3.Distance(target.position, transform.position);
            if (distance < 2)
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