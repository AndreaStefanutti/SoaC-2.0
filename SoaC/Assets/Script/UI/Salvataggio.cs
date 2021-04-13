using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;



public class Salvataggio : MonoBehaviour
{
    // Start is called before the first frame update
    //private DatabaseReference reference;
    private float punteggioMax;
    public float email;
    public string email2;



    void Start()
    {
        email = PlayerPrefs.GetFloat("email");
        //reference = FirebaseDatabase.DefaultInstance.RootReference;
        //PlayerPrefs.SetFloat("HighScore", 0);
    }


    // Update is called once per frame

    

    public void SalvaPunteggio(float punteggio)
    {
        DatabaseReference database= FirebaseDatabase.DefaultInstance.RootReference;
        database.Child("user").Child("Score").SetRawJsonValueAsync(punteggio.ToString());
        
        

    }

}
