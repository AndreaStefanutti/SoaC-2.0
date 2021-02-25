using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class DataBridge : MonoBehaviour
{
    

    public Text usernameInput, passwordInput;
    private Player data;
    private string DATA_URL = "https://soac-14cd3-default-rtdb.firebaseio.com/";
    private DatabaseReference databaseReference;
    [SerializeField] InputField username;
    [SerializeField] InputField password;


    public void Start()
    {
        
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATA_URL);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

    }
    public void SaveData()
    {
        
        if (usernameInput.text.Equals("") && passwordInput.text.Equals(""))
        {
            print("NO DATA");
            return;
        }



        data = new Player(usernameInput.text, passwordInput.text);
        string jsonData = JsonUtility.ToJson(data);

        //databaseReference.Child("Users" + Random.Range(0, 1000000000)).SetRawJsonValueAsync(jsonData);
        databaseReference.Child("Users").SetRawJsonValueAsync(jsonData);



    }

    public void LoadData()
    {
        return;
    }



}
