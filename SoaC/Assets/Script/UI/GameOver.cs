using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Gioco(string Gioco)
    {
        SceneManager.LoadScene(Gioco);

    }
    public void Home(string Home)
    {
        SceneManager.LoadScene(Home);


    }
}
