using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PointScript : MonoBehaviour
{


    public delegate void RemoveOnPointDestroyedDelegate(GameObject pointObject);
    public delegate void IncrementOnPointDestroyedDelegate();


    public static event RemoveOnPointDestroyedDelegate RemoveOnPointDestroyed;
    public static event IncrementOnPointDestroyedDelegate IncrementOnPointDestroyed;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (RemoveOnPointDestroyed != null)
            {
                RemoveOnPointDestroyed(gameObject); // Notify the PointsSpawnerScript that this point is being destroyed
                IncrementOnPointDestroyed(); // Notify the PointCounter that this point is being destroyed
            }
            Destroy(this.gameObject);
        }
    }
}
