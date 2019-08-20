using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private Transform CameraPoint;
    [SerializeField]
    private GameObject[] BackGroundPrefab;

    private float offset = 31.75f;
    private float offset_ImageSpawn = 15.5f;


    void Awake()
    {
        StartingBackground();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (transform.position.x < CameraPoint.position.x)
        {
            int Random_BackGround = Random.Range(0, BackGroundPrefab.Length);
            //Move the position to the end of the next image background
            transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
            //Spawn the image at the position about half the new object's position
            Vector3 ImageSpawnPos = new Vector3(transform.position.x - offset_ImageSpawn, transform.position.y, 0); 

            Instantiate(BackGroundPrefab[Random_BackGround], ImageSpawnPos , Quaternion.identity);
        }
    }

    public void StartingBackground()
    {
        //Hardcoding the inital position because it never changes
        Vector3 StartingPos = new Vector3(-0.1f, 0.6f, 0f);
        Instantiate(BackGroundPrefab[Random.Range(0, BackGroundPrefab.Length)], StartingPos, Quaternion.identity);
    }
}
