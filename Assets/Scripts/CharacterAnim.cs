using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    [HideInInspector]
    public Animator characterAnim;

    private GameState gameState;
    private Collision col;
    

    // Start is called before the first frame update
    void Start()
    {
        characterAnim = GetComponent<Animator>();
        col = GetComponent<Collision>();
        gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButton("Horizontal") && (gameState.isStarting == false))
        {
            characterAnim.SetBool("isRunning", true);
        } 
         else
        {
            characterAnim.SetBool("isRunning", false);
        }

        if (col.onGround == true)
        {
            characterAnim.SetBool("OnGround", true);
        }
       
        else
        {
            characterAnim.SetBool("OnGround", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && gameState.isStarting == false)
        {
            characterAnim.SetTrigger("Jump");
        } 

       
    }
}
