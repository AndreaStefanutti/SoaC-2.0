using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoginHome : MonoBehaviour
{
    public void Home(string Home)
    {
        SceneManager.LoadScene(Home);

    }
}
