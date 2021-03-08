using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]private GameObject enemyShipPrefab;
    [SerializeField]private GameObject[] powerUpsPrefabs;

    private float enemySpawnTimer = 5f;
    private float powerUpSpawnTimer = 10f;

    private float nextEnemySpawn = 0f;
    private float nextPowerUpSpawn = 0f;

    private bool gameRunning = false;
    private bool startGame = false;





    private void Update()
    {
        if(!gameRunning && startGame)
        {
            gameRunning = true;
            StartCoroutines();
        }

        if(gameRunning && !startGame)
        {
            gameRunning = false;
            StopAllCoroutines();
        }

    }


    public void StartCoroutines()
    {
        StartCoroutine(SpawnPowerUpsRoutine());
        StartCoroutine(SpawnEnemyRoutine());
    }

    
        /*
    private void Update()
    {
        if(Time.time >= nextEnemySpawn && gameRunning)
        {
            nextEnemySpawn = Time.time + enemySpawnTimer;
            spawnEnemy();
        }
        if(Time.time >= nextPowerUpSpawn && gameRunning)
        {
            nextPowerUpSpawn = Time.time + powerUpSpawnTimer;
            spawnPowerUp();
        }
    }


    private void spawnEnemy()
    {
        Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7.7f, 7.7f), 7f, 0f), Quaternion.identity);

    }

    private void spawnPowerUp()
    {
        int powerUpID;

        powerUpID = Random.Range(0, 3);

        Instantiate(powerUpsPrefabs[powerUpID], new Vector3(Random.Range(-7.7f, 7.7f), 7f, 0f), Quaternion.identity);

    }

        */

    IEnumerator SpawnEnemyRoutine()
    {


        while(true)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7.7f, 7.7f), 7f, 0f), Quaternion.identity);

            yield return new WaitForSeconds(enemySpawnTimer);
        }
        

    }

    IEnumerator SpawnPowerUpsRoutine()
    {

        int powerUpID;


        
        while(true)
        {

            powerUpID = Random.Range(0, 3);
            
            Instantiate(powerUpsPrefabs[powerUpID], new Vector3(Random.Range(-7.7f, 7.7f), 7f, 0f), Quaternion.identity);
            
            yield return new WaitForSeconds(powerUpSpawnTimer);


        }

    }

    
    public void gameStart(bool gR)
    {
        startGame = gR;
    }


}
    
