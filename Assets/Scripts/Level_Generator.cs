using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Generator : MonoBehaviour
{
    [HideInInspector]
    public GameState gameState;
    [HideInInspector]
    public ScrollingBackground background;


    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private GameObject background_spawner;
    [SerializeField]
    private GameObject[] platformPrefab;
    [SerializeField]
    private Transform generatePoint;
   
    private int i;
    
    private Vector3[] startingPlatformPoint;
    private Vector3 startingPointRespawn;
    private Vector3 startingBackGroundSpawn;

    
    public float distanceBetween;
    private float platformWidth;
    private float startingPlatformNum = 2;
    private float minY = -1.5f;
    private float maxY = 2.5f;



    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        startingPointRespawn = new Vector3(16f, 0.33f, 0f);
        startingBackGroundSpawn = new Vector3(14.21f, -0.6f, 0f);
        StartingPlatform();

    }


    //Update is called once per frame
    void Update()
    {
        if (gameState.respawn == true)
        {
            transform.position = startingPointRespawn;
            background_spawner.transform.position = startingBackGroundSpawn;
            var clone_back = GameObject.FindGameObjectsWithTag("BackGround");
            var clone_plat = GameObject.FindGameObjectsWithTag("Platform");

            foreach (var Platform in clone_plat)
            {
                Destroy(Platform);
            }
            foreach (var BackGround in clone_back)
            {
                Destroy(BackGround);
            }

            background.StartingBackground();
            StartingPlatform();

            gameState.respawn = false;
        }

        if(transform.position.x < generatePoint.position.x)
        {
            float randomY = Random.Range(minY, maxY);
            int randomPlat = Random.Range(0, platformPrefab.Length);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, randomY, transform.position.z);
            Instantiate(platformPrefab[randomPlat], transform.position, Quaternion.identity);
        }


    }

    void StartingPlatform()
    {
        startingPlatformPoint = new[] { new Vector3(5f, -1.4f, 0f), new Vector3(11f, 0.75f, 0f), new Vector3(16.7f, 2.31f, 0f) };

        for (i = 0; i <= startingPlatformNum; i++)
        {
            Instantiate(platform, startingPlatformPoint[i], Quaternion.identity);
            //Debug.Log("Number:" + i);
        }
    }




}
