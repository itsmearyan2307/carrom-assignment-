using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AIShotController : MonoBehaviour
{
    public Transform target; // Target to aim at (e.g., the carrom coin)
    public float shootingForce = 10f; // Force to apply for shooting the striker

    private Rigidbody2D rb;

    public GameObject board;
    private bool hasstrike;
    private bool positionset;
    Transform selftransform;
    Vector2 startpos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        selftransform = transform;
        startpos = transform.position;

    }


    private void Update()
    {
        if (!hasstrike && !positionset)
        {

            selftransform.position = new Vector2(startpos.x, startpos.y);
        }
        if (board.GetComponent<GameManager>().count % 2 != 0)
        {
            StartCoroutine(TakeShots());
           
        }
    }

    IEnumerator TakeShots()
    {
        if (target == null)
        {
           
            yield break;
        }

        while (true)
        {
            hasstrike = true; 
            Vector2 direction = (target.position - transform.position).normalized;
            rb.AddForce(direction * shootingForce);
            if (rb.velocity.magnitude < 0.1f && rb.velocity.magnitude != 0)
            {
                board.GetComponent<GameManager>().count++;
                resetstriker();
            }
            yield return new Update();

            
        }
    }

    private void resetstriker()
    {
        rb.velocity = Vector2.zero;
        hasstrike = false;
        positionset = false;
       
    }
}
