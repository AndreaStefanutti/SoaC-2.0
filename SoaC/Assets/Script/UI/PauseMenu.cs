using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Hosting

;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
   

    public GameObject pauseMenu;
    public bool notPaused;
    
    public Button MyButton;
    
    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
       // if (MyButton.onClick(Pausa))
       if(Input.GetButton("Pausa"))
        {
            if (notPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        notPaused = false;
       
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        notPaused = true;


    }
    public void GotoMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menugioco");
    }
    public void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gioco");
    }


  /*  public void QuitGame()
    {
        Application.Quit();
    }*/
}