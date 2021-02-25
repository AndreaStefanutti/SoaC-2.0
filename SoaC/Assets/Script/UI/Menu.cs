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

        SceneManager.LoadScene(Opzioni);

    }
    public void Credits()
    {


    }
    public void Esci()
    {
        Application.Quit();


    }

}
