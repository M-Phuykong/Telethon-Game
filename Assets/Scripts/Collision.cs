using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Player_control player_control;
    private GameState gameState;
    [HideInInspector]
    public Animator charAnim;

    [Space]
    [Header("Layer")]
    public LayerMask whatisGround;
    
    [Header("Collision")]
    public bool onGround;
    private float groundcheckRadius = 0.25f;
    public Transform groundCheck1;
    public Transform groundCheck2;
    public BoxCollider2D checker;


    // Start is called before the first frame update
    void Start()
    {

        checker = GetComponent<BoxCollider2D>();

        player_control = GameObject.FindWithTag("Player").GetComponent<Player_control>();

        gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();

       

    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(groundCheck1.position, groundcheckRadius, whatisGround)
            || Physics2D.OverlapCircle(groundCheck2.position, groundcheckRadius, whatisGround);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            player_control.enabled = false;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(Death(0.92f));
        }

        if (collision.gameObject.tag == "DeathCollider")
        {
            
            Destroy(gameObject, 0);
            gameState.isDead = true;
            
        }
    }

    IEnumerator Death(float time)
    {
        
        charAnim.SetTrigger("Death");
        yield return new WaitForSeconds(time);
        gameState.isDead = true;
        Destroy(gameObject);
        player_control.enabled = true;
    }

    

}
