using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGFXDamage : MonoBehaviour
{

    private int laserDamage = 10;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();

            if(enemy != null)
            {
                enemy.TakeDamage(laserDamage);
            }

            
            Destroy(gameObject);

        }

    }


}
