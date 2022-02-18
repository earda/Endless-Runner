using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawnManager : MonoBehaviour
{
    public List<GameObject> obstacles;
    public GameObject player; 
    int i = 0;

    private void Update()
    {
        SpawnObstacle(); 
    } 
    public void SpawnObstacle()
    { 
        for (i = 0; i < obstacles.Count; i++)
        {
            if ((obstacles[i].transform.position.z < player.transform.position.z - 7) && GameManager.Instance.isCollectedAllDiamonds==false)
            {
                obstacles[i].transform.position = new Vector3(Random.Range(-1.2f,1.2f), 0, obstacles[i].transform.position.z + 30); 
            }
        }
    } 
}
