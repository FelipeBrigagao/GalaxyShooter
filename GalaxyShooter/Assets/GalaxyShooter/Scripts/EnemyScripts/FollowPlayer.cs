using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public int PlayerDirection()
    {
        int horizontalMove = 0;


        if(player)
        {
            if(transform.position.x < player.transform.position.x - 0.01)
            {
                horizontalMove = 1;
        
            }else if (transform.position.x > player.transform.position.x + 0.01)
            {
                horizontalMove = -1;

            }
            else
            {
                horizontalMove = 0;
            }

        }


        return horizontalMove;
    }


}
