﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidCameraObstruction : MonoBehaviour
{
    public Transform obstruction;
    float zoomSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    private void LateUpdate()
    {
        ViewObstructed();
    }

    void ViewObstructed()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, obstruction.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                obstruction = hit.transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

               /* if (Vector3.Distance(obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, obstruction.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }*/
            }
            else
            {
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                /*if (Vector3.Distance(transform.position, obstruction.position) < 4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }*/
            }
        }
    }

}
