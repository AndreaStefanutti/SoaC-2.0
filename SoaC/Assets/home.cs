using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public void Casa(string Home)
    {
        SceneManager.LoadScene(Home);

    }
}