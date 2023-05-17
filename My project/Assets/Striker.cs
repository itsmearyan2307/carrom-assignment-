using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Striker : MonoBehaviour
{

    public float hitspeed = 250f;
    Rigidbody2D rb;
    Transform selftransform;
    Vector2 startpos;

    public Slider slider;

    Vector2 direction;
    Vector3 mousepos;
    Vector3 mousepos2;
    bool hasstrike = false;
    bool positionset = false; 

    public LineRenderer line;
    public GameObject board;

    Transform target;

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        selftransform = transform;
        startpos = transform.position;

       


    }

    // Update is called once per frame
    void Update()
    {

        line.enabled = false; 
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 inversemouspos = new Vector3(Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y, Input.mousePosition.z);
        mousepos2 = Camera.main.ScreenToWorldPoint(inversemouspos);
        mousepos.y = mousepos2.y - 3; 

        if (mousepos2.y > -2.27f)
        {
            mousepos.y = -2.27f;
        }
        if (mousepos2.y < -5.84f)
        {
            mousepos.y = -5.84f;
        }
        if (mousepos2.x < 1.6f)
        {
            mousepos.x = 1.6f;
        }
        if (mousepos2.x > 7.298794f)
        {
            mousepos.x = 7.298794f;
        }

        if (!hasstrike && !positionset)
        {

            selftransform.position = new Vector2(slider.value, startpos.y);
        }

        if(Input.GetMouseButtonUp(0) && rb.velocity.magnitude == 0 && positionset)
        {
            shootstriker();
        }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {



            if (Input.GetMouseButtonDown(0))
            {

                if (!positionset)
                {
                    positionset = true;
                }
            }
        }

        if(positionset && rb.velocity.magnitude == 0)
        {
            line.enabled = true; 
            line.SetPosition(0, selftransform.position);
            line.SetPosition(1, mousepos2);
        }

        if (rb.velocity.magnitude < 0.1f && rb.velocity.magnitude != 0)
        {
            board.GetComponent<GameManager>().count++; 
            resetstriker();
        }
      
      

    }

     void resetstriker()
    {
        rb.velocity = Vector2.zero;
        hasstrike = false;
        positionset = false;
        line.enabled = false; 
    }

    void shootstriker()
    {

        float x = 0;

        if (positionset && rb.velocity.magnitude == 0)
        {

            x = Vector2.Distance(transform.position, mousepos);
        }
        direction = (Vector3)(mousepos2 - transform.position);
        rb.AddForce(direction *x* hitspeed);
        direction.Normalize();
        hasstrike = true; 
    }
}
