using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PointsSpawnerScript : MonoBehaviour
{

    public GameObject point;
    public int activePoints = 0;
    private List<GameObject> pointsList = new List<GameObject>();

    private void spawnPoint(int max)
    {
        if (pointsList.Count < max)
        {
            Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 1, Random.Range(-10.0F, 10.0F));
            //point = new GameObject();
            pointsList.Add(Instantiate(point, position, Quaternion.identity)); 

            Debug.Log("spawned");
        }
    }




    private void Start()
    {
        spawnPoint(1);
    }

    private void Update()
    {
       
      
       // point.transform.Translate(Vector3.forward * Time.deltaTime * 2f);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("point success");
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destroy the player character
        }
    }

}
