using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private float speed = 50f;
    private int horizontalMove;
        
    private FollowPlayer fp;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fp = GetComponent<FollowPlayer>();
    }

    
    void Update()
    {
        
        if(GameControlling.playMode == 1)
        {
            horizontalMove = fp.PlayerDirection();
        }else
        {
            horizontalMove = 0;
        }

        if (transform.position.y < -7f)
        {
            Reapearing();
        
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalMove * speed * Time.deltaTime, -1 * speed * Time.deltaTime, 0);
    }


    private void Reapearing()
    {
        
            transform.position = new Vector3(Random.Range(-7.7f, 7.7f), 7f, 0f);
        
    }

}
