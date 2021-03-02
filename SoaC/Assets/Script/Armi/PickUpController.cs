using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    //public ProjectileGun gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool slotFull;
    public GameObject omino;
    public bool equiped;

    private void Start()
    {
      
            //gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            slotFull = false;
            equiped = false;
        
    }

    private void Update()
    {
       
        slotFull= omino.GetComponent<MyPlayer>().arma;
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        //if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();
        if (distanceToPlayer.magnitude <= pickUpRange && !slotFull)
        {
            //GetComponent<FloatingObject>().enabled = false;
            //GetComponent<Rigidbody>().useGravity = true;
            PickUp();
        }
        //Drop if equipped and "Q" is pressed
        if (slotFull && Input.GetKeyDown(KeyCode.Q)) Drop();

    }

    private void PickUp()
    {
        equiped = true;
        slotFull = true;
        omino.GetComponent<MyPlayer>().arma = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        //gunScript.enabled = true;
    }

    private void Drop()
    {
        equiped = false;
        slotFull = false;
        omino.GetComponent<MyPlayer>().arma = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = UnityEngine.Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        //Disable script
        //gunScript.enabled = false;
    }
}
