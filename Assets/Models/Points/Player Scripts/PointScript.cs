using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PointScript : MonoBehaviour
{
    PointsSpawnerScript p;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("point success");
        if (other.CompareTag("Player"))
        {
            //p.pointsList.Remove(p.point);
             // Destroy the player character
            
        }

    }

}
