using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    public GameObject spawnee;
    public float spawnDelay; //da quando l'arma è stata presa
    private bool flag;



    void Start()
    {
        flag = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == spawnee.tag && !flag)
        {
            StartCoroutine(wait());
            flag = true;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(spawnDelay);
        spawnee = Instantiate(spawnee, transform.position, transform.rotation);
        flag = false;
        spawnee.GetComponent<PickUpController>().slotFull = false;
        spawnee.GetComponent<Transform>().localScale = new Vector3(2, 2, 2);
    }
}

