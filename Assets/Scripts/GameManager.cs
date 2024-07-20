using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int totalCubes = 5;
    private float timeLimit = 120f; // 2 minutes
    private float timeRemaining;
    private bool gameOver;
    private float fallTimer = 5.0f;

    public TextMeshProUGUI timerText;
    public PlayerController playerController;

    void Start()
    {
        timeRemaining = timeLimit;
        gameOver = false;
        UpdateTimerText();
        
    }

    void Update()
    {
        if (gameOver)
            return;

        timeRemaining -= Time.deltaTime;
        UpdateTimerText();

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            CheckGameOver();
        }
        if (!playerController.isOnGround)
        {
            fallTimer -= Time.deltaTime;
            if(fallTimer <= 0)
            {
                LoseGame();
            }
        }
        else if(playerController.isOnGround && fallTimer != 5.0f)
        {
            fallTimer = 5.0f;
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void CubeCollected()
    {
        totalCubes--;

        if (totalCubes <= 0)
        {
            WinGame();
        }
    }

    void CheckGameOver()
    {
        if (totalCubes > 0)
        {
            LoseGame();
        }
    }

    void WinGame()
    {
        gameOver = true;
        Debug.Log("You win!");
    }

    void LoseGame()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}