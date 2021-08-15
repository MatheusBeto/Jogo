using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManeger : MonoBehaviour
{
    public Vector3 spawnPosition;
    public Transform playerTransform;

    private void Update()
    {
        if(playerTransform.position.y < -5)
        {
            playerTransform.position = spawnPosition;
        }
    }
}
