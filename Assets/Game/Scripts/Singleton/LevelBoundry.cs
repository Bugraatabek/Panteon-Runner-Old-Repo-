using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundry : MonoBehaviour
{
    public float leftSideBoundry = -8.5f;
    public float rightSideBoundry = 8.5f;

    public static LevelBoundry Instance { get; private set; }
    void Awake()
    {
        if (Instance)
            Destroy(gameObject);
        else
        {
            Instance = this;
        }
    }
    
}
