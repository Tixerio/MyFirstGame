using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSpawnerScript : MonoBehaviour
{
    public GameObject point;
    public List<GameObject> pointsList = new List<GameObject>();


    //here we check if we reached the max of possible point objects in the world, if not, give it a random position
    // and spawn it into the  world with Instantiate while also adding it to the object list
    private void spawnPoint(int max)
    {
        if (pointsList.Count < max)
        {
            Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 1, Random.Range(-10.0F, 10.0F));
            pointsList.Add(Instantiate(point, position, Quaternion.identity));
            Debug.Log("Point spawned");
        }
    }

    private void Start()
    {
        // Subscribe pattern metho, here we subscripe to the publisher in pointscript
        // and add the method which should be executed when we get a message
        PointScript.OnPointDestroyed += RemovePointFromList;
    }

    private void Update()
    {
        spawnPoint(2);
    }

    //Method to remove a point from the pointlist
    private void RemovePointFromList(GameObject pointObject)
    {
        if (pointsList.Contains(pointObject))
        {
            pointsList.Remove(pointObject);
            Debug.Log("Point removed from the list.");
        }
    }


    // this method is used to remove the subscription in case of the object being destroyed
    private void OnDestroy()
    {
        PointScript.OnPointDestroyed -= RemovePointFromList;
    }
}
