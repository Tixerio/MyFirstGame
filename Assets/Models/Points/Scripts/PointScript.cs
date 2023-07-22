using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public delegate void PointDestroyedDelegate(GameObject pointObject);
    public static event PointDestroyedDelegate OnPointDestroyed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnPointDestroyed != null)
            {
                OnPointDestroyed(gameObject); // Notify the PointsSpawnerScript that this point is being destroyed
            }
            Destroy(this.gameObject);
        }
    }
}
