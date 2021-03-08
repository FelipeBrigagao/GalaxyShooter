using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerStats player = other.GetComponent<PlayerStats>();

            if(player != null)
            {
                player.TakeDamage();
            }


            this.gameObject.GetComponent<EnemyStats>().Die();

        }
    }


}
