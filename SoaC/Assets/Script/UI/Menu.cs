using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(string Gioco)    {
        SceneManager.LoadScene(Gioco);

    }
    public void Opzioni(string Opzioni)
    {
        print("op1");
        SceneManager.LoadScene(Opzioni);
        print("op2");

    }
    public void Login(string Registrazione)
    {
        print("r1");
        SceneManager.LoadScene(Registrazione);
        print("r2");

    }
    public void Esci()
    {
        Application.Quit();


    }

}
