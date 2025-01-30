using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalGameTime = 600f; // 10 minutes (600 seconds)
    public float playerTurnTime = 60f; // 1 minute
    public float enemyTurnTime = 60f; // 1 minute
    public float gameTimer;
    public float turnTimer;

    public  bool isGameActive = false;
    public bool isPlayerTurn = true; // sPlayer starts first

    public Text gameTimerText;
    public Text turnTimerText;
    //public Button submitButton; // Disable when time is up

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (isGameActive)
        {
            UpdateGameTimer();
            UpdateTurnTimer();
        }
    }

    void StartGame()
    {
        gameTimer = totalGameTime;
        turnTimer = playerTurnTime;
        isGameActive = true;
        isPlayerTurn = true;
        UpdateGameTimerDisplay();
        UpdateTurnTimerDisplay();
    }

    void UpdateGameTimer()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
            UpdateGameTimerDisplay();
        }
        else
        {
            gameTimer = 0;
            isGameActive = false;
            GameOver();
        }
    }

    void UpdateTurnTimer()
    {
        if (turnTimer > 0)
        {
            turnTimer -= Time.deltaTime;
            UpdateTurnTimerDisplay();
        }
        else
        {
            EndTurn(); // Switch turn when time runs out
        }
    }

    public void EndTurn()
    {
        isPlayerTurn = !isPlayerTurn; // Switch turn
        turnTimer = isPlayerTurn ? playerTurnTime : enemyTurnTime;
        //submitButton.interactable = isPlayerTurn; // Only enable button for the player
    }

    void UpdateGameTimerDisplay()
    {
        gameTimerText.text = "Game Time: " + Mathf.FloorToInt(gameTimer / 60) + ":" + Mathf.FloorToInt(gameTimer % 60);
    }

    void UpdateTurnTimerDisplay()
    {
        turnTimerText.text = (isPlayerTurn ? "Player" : "Enemy") + " Time: " + Mathf.CeilToInt(turnTimer);
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        gameTimerText.text = "Game Over!";
        turnTimerText.text = "";
        //submitButton.interactable = false;
    }
}
