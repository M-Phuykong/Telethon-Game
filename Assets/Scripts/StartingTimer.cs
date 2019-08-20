using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingTimer : MonoBehaviour
{
   
    public GameState gameState;

    public Rigidbody2D player_rb;

    public TMPro.TextMeshProUGUI timerText;
    
    public float timeLeft;
   

    

    public void Awake()
    {
        player_rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();

        
        player_rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
         
    }


    public void NextSecond(string Flag)
    {
        if (Flag == "MoveNextSecond" && gameState.isStarting) 
        {
            timeLeft -= 1;
            timerText.text = timeLeft.ToString("0");
            if (timeLeft <= 0)
            {
                
                timerText.text = "GO!";
                StartCoroutine(DisableText());
                player_rb.constraints = RigidbodyConstraints2D.None;
                player_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
               

                return;
                
            }
        }
            
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(1f);
        timerText.enabled = false;
        yield return new WaitForSeconds(0.1f);     
    }


}
