using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opzioni : MonoBehaviour
{
    public void Home(string Home)
    {
        SceneManager.LoadScene(Home);

    }
    public void Volume(string Volume)
    {
        SceneManager.LoadScene(Volume);


    }
    public void Shop(string Shop)
    {
        SceneManager.LoadScene(Shop);

    }
    public void Credits(string Credits)
    {

        SceneManager.LoadScene(Credits);

    }
    public void Statistiche(string Statistiche)
    {
        SceneManager.LoadScene(Statistiche);
    }

}
