using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnManager : MonoBehaviour
{
    public List<GameObject> grounds;
    public GameObject finalGround;
    public GameObject player; 
    public GameObject collectablePrefabs;
    public List<GameObject> diamonPlaces;
    private bool spawnCount=false;
    private void Start()
    {
        SpawnCollectableObjects();
    }
    private void Update()
    {
        CheckGroundPosition();
    }

    private void CheckGroundPosition()
    {
        if ((grounds[0].transform.position.z <= player.transform.position.z - 15) && GameManager.Instance.isCollectedAllDiamonds==false)
        {
            grounds[0].transform.position = grounds[grounds.Count - 1].transform.position + Vector3.forward * 7;
            grounds.Add(grounds[0].gameObject);
            grounds.RemoveAt(0);
            spawnCount = true;
        }
        if (GameManager.Instance.score == 480 && spawnCount==true)
        {
            GameManager.Instance.isCollectedAllDiamonds = true;

            Instantiate(finalGround, grounds[grounds.Count-1].transform.position+Vector3.forward*5,Quaternion.identity);
            spawnCount = false;

        }
    }

    public void SpawnCollectableObjects()
    {
        for (int j = 0; j < diamonPlaces.Count; j++)
        {
            Instantiate(collectablePrefabs, diamonPlaces[j].transform);
        }            
    }
}
