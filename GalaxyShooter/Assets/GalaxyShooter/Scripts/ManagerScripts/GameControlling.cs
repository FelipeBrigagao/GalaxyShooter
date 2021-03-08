using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlling : MonoBehaviour
{
    public static int playMode;
    
    public bool gameRunning = false;
   
    private SpawnManager sM;
    private UIManager uiM;

    public GameObject player;
    public GameObject playerOne;
    public GameObject playerTwo;

    Vector3 playerOneOffset = new Vector3(-4.5f, 0f, 0f);
    Vector3 playerTwoOffset = new Vector3(4.5f, 0f, 0f);

    private bool gamePaused = false;


    void Start()
    {
        playMode = SceneManager.GetActiveScene().buildIndex;
       
        sM = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        uiM = GameObject.Find("Canvas").GetComponent<UIManager>();

        gameRunning = false;

        uiM.turnOnOffLivesGFX(false);
        uiM.turnOnOffScoreTXT(false);
        uiM.turnOnOffTitleScreen(true);
        //desligar os gfx do ui manager

        
    }

    void Update()
    {
        if (!gameRunning)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameRunning = true;
                switch (playMode)
                {
                    case 1:
                        Instantiate(player, transform.position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(playerOne, transform.position + playerOneOffset, Quaternion.identity);
                        Instantiate(playerTwo, transform.position + playerTwoOffset, Quaternion.identity);
                        break;
                    default:
                        break;
                }
                
                //fala pro sm começar a spawnar coisas
                sM.gameStart(gameRunning);
                uiM.turnOnOffLivesGFX(true);
                uiM.turnOnOffScoreTXT(true);
                uiM.turnOnOffTitleScreen(false);

            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ReturnToMenu();
            }
            
        }

        if(gameRunning && Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

    }

    public void PauseGame()
    {
        
        gamePaused = !gamePaused;
        uiM.turnOnOffPauseScreen(gamePaused);

        if (gamePaused)
        {
            Time.timeScale = 0;
        }else if (!gamePaused)
        {
            Time.timeScale = 1;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameEnded()
    {
        //yield return new WaitForSeconds(2f);
        gameRunning = false;
        sM.gameStart(gameRunning);
        uiM.turnOnOffLivesGFX(false);
        uiM.turnOnOffScoreTXT(false);
        uiM.turnOnOffTitleScreen(true);


        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemys)
        {
            enemy.GetComponent<EnemyStats>().endGame();
        }


        GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUp");

        foreach(GameObject pu in powerUps)
        {
            Destroy(pu);
        }

    }


}
