using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    private GameObject player;
    public GameObject PauseMenuUI;

    public static bool GameIsPaused;

    public Player_control player_control;
    public Camera_Control camera_control;

    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player_control = player.GetComponent<Player_control>();
        
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            if (player == null)
            {
                Start();
            }
        } catch (Exception ex)
        {
            if (ex is MissingReferenceException || ex is NullReferenceException)
            {
                return;
            }
            throw;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == false)
            {
                //Debug.Log("Paused");
                Pause(); 
                
            } else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        player_control.xRaw = 0;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        player_control.enabled = false;
        camera_control.GetComponent<Camera_Control>().enabled = false;

        
        
        GameIsPaused = true;
    }

    public void Resume()
    {
        player_control.enabled = true;
        PauseMenuUI.SetActive(false);
        camera_control.GetComponent<Camera_Control>().enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        
    }

    
}
