using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    [HideInInspector]
    public GameState gamestate;

    [SerializeField]
    private float speed;

    void FixedUpdate()
    {
        if (!gamestate.isStarting)
        {
           
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);

        }


    }
}
