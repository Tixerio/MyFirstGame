using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{


    public Text textElement;

    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        PointScript.IncrementOnPointDestroyed += incrementPoints;

        textElement.text = points.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (points.ToString() != textElement.text) {
            textElement.text = points.ToString();
        }
    }


    private void incrementPoints()
    {
        points++;
    }

}
