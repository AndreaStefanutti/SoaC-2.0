using UnityEngine;
using System.Collections;

///<summary>
///
///</summary>

public class WeaponRotator : MonoBehaviour
{
    public Transform camTransform;

    void LateUpdate()
    {
        transform.rotation = camTransform.rotation;
    }
}
