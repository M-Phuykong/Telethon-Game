using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Meter_Start meter_start;
    private Odometer odometer;
    private GameState gameState;
    private DeathScreen deathScreen;
   

    private Vector3 SpawnPoint;
    private Vector3 CameraResetPoint;

    private void Awake()
    {
        

        gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();

        meter_start = GameObject.FindWithTag("StartingArea").GetComponent<Meter_Start>();

        odometer = GameObject.FindWithTag("ScoreCanvas").GetComponent<Odometer>();

        deathScreen = GameObject.FindWithTag("DeathScreen").GetComponent<DeathScreen>();

        SpawnPoint = new Vector3(-4.77f, -2.365f, 0f);
        CameraResetPoint = new Vector3(1.17f, 1.19f, -1f);
    }


    public void RespawnFunction()
    {
        //Debug.Log("Respawn");

        if (gameState.respawn == true)
        {
           
            if (meter_start.hasPassedLine == true)
            {
                meter_start.hasPassedLine = false;
            }

            var ParticleSpawn = GameObject.FindGameObjectsWithTag("Particle");

            foreach (var Particle in ParticleSpawn)
            {
                Destroy(Particle);
            }

            Camera.main.transform.position = CameraResetPoint;


            deathScreen.deathScore.text = "0";
            odometer.totalDistance.text = "0";
            odometer.distanceTravel = 0f;

            Instantiate(PrefabManager.Instance.player, SpawnPoint, Quaternion.identity);


            

        }

        gameState.isDead = false;
        
    }
}
