
using UnityEngine;
using System.Collections;

///<summary>
///
///</summary>

public class AutoDestroy : MonoBehaviour
{
    public float destroyTime = 5;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
