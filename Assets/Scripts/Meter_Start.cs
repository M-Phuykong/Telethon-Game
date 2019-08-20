using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter_Start : MonoBehaviour
{

    public bool hasPassedLine;

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasPassedLine = true;
            

            //Debug.Log("Start!");
        }
       

    }

   

   

}
