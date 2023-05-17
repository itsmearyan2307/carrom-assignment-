using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCollector : MonoBehaviour
{
    public Text point;
    public int points = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pucks")
        {
            Destroy(collision.gameObject);
            points++;
            Debug.Log("point");

        }
        if (collision.gameObject.tag == "queen")
        {
            Destroy(collision.gameObject);
            points = points+2;
            Debug.Log("point");

        }



        point.text = points.ToString();
    }
   
   
   

}
