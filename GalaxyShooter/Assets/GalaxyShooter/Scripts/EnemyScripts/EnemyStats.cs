using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int enemyActualHealth;
    private int enemyMaxHealth = 100;

    private int enemyPoints = 10;
    
    public GameObject enemyExplosion;
    [SerializeField] private AudioClip explosionSound;

    private PlayerStats ps;

    private bool gameEnded = false;

    void Start()
    {
        enemyActualHealth = enemyMaxHealth;

        GameObject pl;

        pl = GameObject.FindGameObjectWithTag("Player");

        ps = pl.GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        if(enemyActualHealth <= 0)
        {
            enemyActualHealth = 0;

            if (ps)
            {
                ps.AddScore(enemyPoints);
            }

            Die();
        }

        if (gameEnded)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        enemyActualHealth -= damage;
    }

    public void Die()
    {
        AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);

        Instantiate(enemyExplosion, transform.position, Quaternion.identity);

        Destroy(gameObject);

    }




    public void endGame()
    {
        gameEnded = true;
    }

}
