using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //the parent game object to the spawn points
    public GameObject spawnPoints;
    //an array of possible objects to spawn
    public GameObject[] objectsToSpawn;
    //the chance an object is spawned at each spawn point
    public float chanceOfSpawn;
    // Start is called before the first frame update
    void Start()
    {
        //go through each spawn point
        for(int i=0; i<spawnPoints.transform.childCount; i++)
        {
            //if the chance occurs
            if(Random.value < chanceOfSpawn)
            {
                //instantiate a random object
                var obj = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)]);
                //parent it to the spawn point
                obj.transform.parent = spawnPoints.transform.GetChild(i);
                //set its location to the spawn point(local location to zero)
                obj.transform.localPosition = Vector3.zero;
            }
        }
    }
}
