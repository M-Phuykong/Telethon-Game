using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyplatform : MonoBehaviour
{
    public GameObject platform;

    

    private float DestroyTime = 2f;

    void Start()
    {
        //RigidBody2D is attacthed to the wall in order for OnTrigger2D
        platform = GameObject.FindWithTag("Platform");
   
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            Destroy(col.gameObject, DestroyTime);

        }

        if (col.gameObject.tag == "Particle")
        {
            Destroy(col.gameObject, 0f);

        }

    }


}
