using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PointsSpawnerScript : MonoBehaviour
{

    public GameObject point;
    public int activePoints = 0;
    public List<GameObject> pointsList = new List<GameObject>();

    private void spawnPoint(int max)
    {
        if (pointsList.Count < max)
        {
            Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 1, Random.Range(-10.0F, 10.0F));
            //point = new GameObject();
            pointsList.Add(Instantiate(point, position, Quaternion.identity));
            Debug.Log(pointsList.Count);
            Debug.Log("spawned");
        }
    }

    private void Start()
    {
      
    }

    private void Update()
    {
        spawnPoint(1);
       


    }


}
