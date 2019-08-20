using UnityEngine;
using System;

public class Odometer : MonoBehaviour
{
    private GameObject player;
    private GameObject meter;

    private Rigidbody2D player_velo;
    private Meter_Start meter_start;
    private Player_control player_control;

    [HideInInspector]
    public TMPro.TextMeshProUGUI totalDistance;
    [HideInInspector]
    Vector3 lastPosition;
    [HideInInspector]
    public string str_distanceTravel;

    [Header("Distance")]
    public float distanceTravel;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        meter = GameObject.Find("Starting_Area");
     

        player_control = player.GetComponent<Player_control>();

        player_velo = player.GetComponent<Rigidbody2D>();

        meter_start = meter.GetComponent<Meter_Start>();
        

        totalDistance = GameObject.FindWithTag("TotalDistance").GetComponent<TMPro.TextMeshProUGUI>();

        lastPosition = new Vector3(player.transform.position.x, 0, 0);


    }

    // Update is called once per frame
    void Update()
    {
        //Try and Catch block for the deathscreen in which Rigidbody2d is missing until
        //player hits respawn
        try
        {
            if (player_velo == null)
            {
                Start();
            }
        }
        catch (Exception ex)
        {
            if (ex is NullReferenceException || ex is MissingReferenceException)
            {
                return;
            }
            throw;
        }

        if (totalDistance != null)
        {
            if (player_control.xRaw > 0 && meter_start.hasPassedLine == true)
            {
                distanceTravel += Mathf.Ceil(Vector2.Distance(new Vector2(player.transform.position.x, 0), lastPosition) / 12);

                lastPosition = player.transform.position;

                str_distanceTravel = distanceTravel.ToString();

                totalDistance.text = str_distanceTravel;
            }

        }
            
        
    }
}
