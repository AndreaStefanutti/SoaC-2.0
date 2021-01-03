using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 cameraOffset;
    [Range(0.01f, 1.0f)]
    public float smootFactor = 0.5f;
    public bool LookAtPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 newPosition = player.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smootFactor);

        if (LookAtPlayer)
            transform.LookAt(player);
    }
}
