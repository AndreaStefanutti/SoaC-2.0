using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DannoPlayer : MonoBehaviour
{

    public int Vita = 50;
    int danno = 10;
    // Start is called before the first frame update
    void Start()
    {
        print(Vita);
        
    }

    // Update is called once per frame
   void CollisioneVerificata(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy" )
        {
            Vita -= danno;
            print(" IL player è stato colpito");
        }
    }
}
