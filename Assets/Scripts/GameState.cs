using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
   [Header("States")]
    public bool isDead;
    public bool respawn;
    public bool isStarting;

    private void Awake()
    {
        StartCoroutine(Start());
    }

    IEnumerator Start()
    {
        isStarting = true;
        yield return new WaitForSeconds(4f);
        isStarting = false;

    }
}
