using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;

    [SerializeField] private Image livesGFX;
    [SerializeField] private Image livesPlayerTwoGFX;
    [SerializeField] private Text scoreTXT;
    [SerializeField] private Text maxScoreTXT;
    [SerializeField] private Image titleScreen;
    [SerializeField] private GameObject pauseScreen;


    public void UpdateLives(int livesNum, int id)
    {
        if(id == 2)// só terá id == 2 se for coop
        {
            livesPlayerTwoGFX.sprite = lives[livesNum];
            return;
        }

        livesGFX.sprite = lives[livesNum];
    }

    public void UpdateScore(int playerScore)
    {
        scoreTXT.text = "Score: " + playerScore.ToString();
    }

    public void UpdateMaxScore(int playerMaxScore)
    {
        maxScoreTXT.text = "Max. Score: " + playerMaxScore;
    }

    public void turnOnOffScoreTXT(bool onoff)
    {
        scoreTXT.enabled = onoff;

        if(GameControlling.playMode == 1)
        {
            maxScoreTXT.enabled = onoff;
        }
    }

    public void turnOnOffLivesGFX(bool onoff)
    {
        livesGFX.enabled = onoff;
        if(GameControlling.playMode == 2)
        {
            livesPlayerTwoGFX.enabled = onoff;
        }
    }

    public void turnOnOffTitleScreen(bool onoff)
    {
        titleScreen.enabled = onoff;
    }

    public void turnOnOffPauseScreen(bool onoff)
    {
        pauseScreen.SetActive(onoff);
    }

}
