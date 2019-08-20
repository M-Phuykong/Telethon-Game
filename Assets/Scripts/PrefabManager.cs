using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject player;

    private static PrefabManager m_Instance;

    public static PrefabManager Instance{ get { return m_Instance; } }

    private void Awake()
    {
        if (m_Instance != null && m_Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        m_Instance = this;
        //DontDestroyOnLoad(gameObject);
    }


}
