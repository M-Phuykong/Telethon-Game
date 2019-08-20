using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrail : MonoBehaviour
{
    [HideInInspector]
    public bool makeGhost;

    [Header("Ghost Effect")]
    public GameObject Ghost;
    public float ghostDelay;
    private float ghostDelaySecond;
    private Sprite currentSprite;



    void Start()
    {
        ghostDelaySecond = ghostDelay;
        currentSprite = GetComponent<SpriteRenderer>().sprite;
    }

   
    void Update()
    {
        if (makeGhost)
        {
            if (ghostDelaySecond > 0)
            {
                ghostDelaySecond -= Time.deltaTime;
            }
            else
            {

                GameObject currentGhost = Instantiate(Ghost, transform.position, transform.rotation);

                currentGhost.GetComponent<SpriteRenderer>().sprite = currentSprite;

                ghostDelaySecond = ghostDelay;

                Destroy(currentGhost, 0.5f);            

            }

            
        }
    }
}
