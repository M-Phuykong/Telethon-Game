using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject MainMenuUI;
    public GameObject ControlsUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Return();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Starting_Level", LoadSceneMode.Single);
    }

    public void Return()
    {
        MainMenuUI.SetActive(true);
        ControlsUI.SetActive(false);
    }

    public void Controls()
    {
        MainMenuUI.SetActive(false);
        ControlsUI.SetActive(true);
        
    }
}
