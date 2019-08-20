using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    private Odometer odometer;
    private Respawn respawn;

    [HideInInspector]
    public GameObject DeathMenu_UI;
    [HideInInspector]
    public GameState gameState;
    [HideInInspector]
    public StartingTimer startingTimer;

    [Header("Score")]
    public TMPro.TextMeshProUGUI highscore;
    public TMPro.TextMeshProUGUI deathScore;
    public TMPro.TextMeshProUGUI New_HighScore;
    
    void Start()
    {
        respawn = GameObject.FindWithTag("Player").GetComponent<Respawn>();

        deathScore = GameObject.FindWithTag("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();

        odometer = GameObject.FindWithTag("ScoreCanvas").GetComponent<Odometer>();

        PlayerPrefs.SetFloat("HighScore", 0f);
    }
    
    void Update()
    {

        if (gameState.isDead)
        {
            DeathMenu_UI.SetActive(true);

            if (PlayerPrefs.GetFloat("HighScore") <= 0)
            {
                PlayerPrefs.SetFloat("HighScore", odometer.distanceTravel);
            } 

            if ( odometer.distanceTravel > PlayerPrefs.GetFloat("HighScore"))
            {
                StartCoroutine(Blinking_Text());
                PlayerPrefs.SetFloat("HighScore", odometer.distanceTravel);
                highscore.text = PlayerPrefs.GetFloat("HighScore").ToString() + "m";


            } else
            {
                highscore.text = PlayerPrefs.GetFloat("HighScore").ToString() + "m";
            }

            if (odometer.distanceTravel <= 0)
            {
                deathScore.text = "0m";
            }
            else
            {
                
                deathScore.text = odometer.str_distanceTravel + "m";
            }

        } else
        {
            DeathMenu_UI.SetActive(false);
            
        }

        

        
    }

    public void RespawnButton()
    {
        gameState.respawn = true;
        respawn.RespawnFunction();
        
    }

    public IEnumerator Blinking_Text()
    {
        while (DeathMenu_UI.activeInHierarchy) 
        {
            New_HighScore.text = "New HighScore!";
            yield return new WaitForSeconds(0.75f);
            New_HighScore.text = "";
            yield return new WaitForSeconds(0.75f);
        }
       
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }




}
