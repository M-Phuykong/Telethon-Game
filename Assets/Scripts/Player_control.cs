using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    //Accessing Other Scripts
    private Collision coll;
    private GameState gameState;
    private DashState dashState;
    public ChromaticAberration ChromeAberration_Effect;


    [HideInInspector]
    public Transform feet;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector] 
    public float xRaw, yRaw;

    //Boolean Values
    private bool hasDashed;
    private bool facingRight = true;

    [Space]
    [Header("Stats")]
    public float speed = 5.0f;
    public float jumpforce = 5.5f;
    public float dashTimer;
    public float maxDash = 50f;

    [Space]
    [Header("Effects")]
    [SerializeField]
    private GameObject JumpParticlePrefab;
    [SerializeField]
    private GhostTrail ghosteffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        coll = GetComponent<Collision>();

        gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();

        ChromeAberration_Effect = GameObject.FindWithTag("MainCamera").GetComponent<ChromaticAberration>();

    }

    void Update()
    {
        
        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(xRaw, yRaw);

        Walk(dir);

        //Checking for facing direction
        if (Input.GetAxis("Horizontal") > 0 && facingRight == false)
        {
            Flip();
        }
        else if (Input.GetAxis("Horizontal") < 0 && facingRight == true)
        {
            Flip();
        } 

        if (Input.GetKeyDown(KeyCode.UpArrow) && (coll.onGround == true))
        {
            Jump();
            StartCoroutine(DisableGhostEffect());

        }

        if (coll.onGround)
        {
            hasDashed = false;
        }


        //Control Section for Dashing
        switch (dashState)
        {
            case DashState.Ready:

                bool isDashKeyDown = Input.GetKeyDown(KeyCode.Space);
                if (isDashKeyDown && !hasDashed)
                {
               
                    if (xRaw != 0 || yRaw != 0)
                    {
                        //Debug.Log("Ready");

                        Dash();
                        
                    } else if (xRaw == 0)
                    {
                        //Debug.Log("ground dash");
                        Dash();
                    }

                    hasDashed = true;
                    dashState = DashState.isDashing;

                }
                break;

            case DashState.isDashing:

                dashTimer += Time.deltaTime + 10;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;

                    //Debug.Log("isDashing");

                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:

                dashTimer -= Time.deltaTime + 10;

                rb.gravityScale = 1f;

                if (dashTimer <= 0)
                {
                    dashTimer = 0;

                    //Debug.Log("Cooldown");                    

                    dashState = DashState.Ready;
                }
                //ChromeAberration_Effect.enabled = false;
                break;
        }
    }

    void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    void Dash()
    {
        rb.gravityScale = 0;

        if (xRaw == 0)
        {
            float direction = transform.rotation.eulerAngles.y;
            float distance = 6.5f;

            if (direction > 1)
            {
                //Debug.Log("Left");
                rb.velocity = -new Vector2(distance * maxDash, rb.velocity.y);
            }
            else if (direction <= 1)
            {
                rb.velocity = new Vector2(distance * maxDash, rb.velocity.y);
                //Debug.Log("right");
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x * maxDash, rb.velocity.y);
        }

        StartCoroutine(Effect());

    }


    void Jump()
    {
       
        float botOffset = -0.787f;
        //Setting Particle spawn point based on player position
        Vector3 particleposition = new Vector3(transform.position.x, transform.position.y + botOffset, transform.position.z);

        if (gameState.isStarting == false)
        {
            ghosteffect.makeGhost = true;
            //Make the particle
            Instantiate(JumpParticlePrefab, particleposition, Quaternion.identity);
        }
       
        //Just multiplying the y velocity by Vector2.up(0,1) and jumpforce
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity = Vector2.up * jumpforce;

        StartCoroutine(DisableGhostEffect());

        
    }

    //Making sure character always face the right way
    void Flip()
    {
        if (gameState.isStarting == false)
        {
            //Basically making it false, fancier way
            facingRight = !facingRight;
            //Rotate on y axis 180 degree
            transform.Rotate(0f, 180f, 0f, Space.Self); 
        }
       
    }

    public enum DashState
    {
        Ready,
        isDashing,
        Cooldown
    }

    IEnumerator DisableGhostEffect()
    {
        yield return new WaitForSeconds(0.5f);
        ghosteffect.makeGhost = false;
        yield return new WaitForSeconds(0.5f); 
    }

    IEnumerator Effect()
    {
        ChromeAberration_Effect.enabled = true;
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
        yield return new WaitForSeconds(0.4f);
        ChromeAberration_Effect.enabled = false;
    }
    
}
