using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;

public class Registrazione : MonoBehaviour
{
    public GameObject AuthController;
    public void Log(string Home)
    {

        AuthController.GetComponent<AuthController>().Login();

        SceneManager.LoadScene(Home);
        
    } 

public void Anonimo(string Anonimo)
{
        AuthController.GetComponent<AuthController>().Login_Anonymous();
            
    SceneManager.LoadScene(Anonimo);
}
}
    
    
     



