using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int count;
    public GameObject x;
    public GameObject y; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count % 2 == 0)
        {
            x.SetActive(true);
            y.SetActive(false);

        }
        else
        {

            x.SetActive(false);
            y.SetActive(true);
        }
    }
}
