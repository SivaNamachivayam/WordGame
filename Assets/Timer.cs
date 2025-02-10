using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class Timer : MonoBehaviour
{
    public float totalGameTime = 600f; // 10 minutes (600 seconds)
    public float playerTurnTime = 60f; // 1 minute
    public float enemyTurnTime = 60f; // 1 minute
    public float gameTimer;
    public float turnTimer;

    public bool isGameActive = false;
    public bool isPlayerTurn = true; // sPlayer starts first

    public TextMeshProUGUI gameTimerText;
    public TextMeshProUGUI turnTimerText;
    //public Button submitButton; // Disable when time is up

    public static Timer Data;

    public void Awake()
    {
        Data = this;
    }

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
            AutoEndTurn(); // Switch turn when time runs out
        }
    }

    public void AutoEndTurn()
    {
        if (OnlyData.Data.gametype == GameType.pass)
        {
            GameController.data.confirmationID = "SkipTurn";
            GameController.data.ConfirmDialog();
            Debug.Log("AUTO CALL SKIP FN");
            GameController.data.confirmationID = string.Empty;
            isPlayerTurn = !isPlayerTurn; // Switch turn
            turnTimer = isPlayerTurn ? playerTurnTime : enemyTurnTime;
        }
        else if (GameController.data.PV.IsMine)
        {
            GameController.data.confirmationID = "SkipTurn";
            GameController.data.ConfirmDialog();
            Debug.Log("AUTO CALL SKIP FN");
            GameController.data.confirmationID = string.Empty;
            isPlayerTurn = !isPlayerTurn; // Switch turn
            turnTimer = isPlayerTurn ? playerTurnTime : enemyTurnTime;
        }

    }

    public void EndTurn()
    {
        isPlayerTurn = !isPlayerTurn; // Switch turn
        turnTimer = isPlayerTurn ? playerTurnTime : enemyTurnTime;
    }

    void UpdateGameTimerDisplay()
    {
        gameTimerText.text = "Game Time: " + Mathf.FloorToInt(gameTimer / 60) + ":" + Mathf.FloorToInt(gameTimer % 60);
    }

    void UpdateTurnTimerDisplay()
    {
        if (OnlyData.Data.gametype == GameType.pass)
        {
            turnTimerText.text = GameController.data.currentPlayerTxt.text + " Time: " + Mathf.CeilToInt(turnTimer);
        }
        else if (OnlyData.Data.gametype == GameType.Multi)
        {
            if (GameController.data.PV.IsMine)
            {
                turnTimerText.text = "Player" + " Time: " + Mathf.CeilToInt(turnTimer);
                GameController.data.currentPlayerTxt.text = "Player";
            }
            else if (!GameController.data.PV.IsMine)
            {
                turnTimerText.text = "Enemy" + " Time: " + Mathf.CeilToInt(turnTimer);
                GameController.data.currentPlayerTxt.text = "Enemy";
            }

        }
    }

    void GameOver()
    {

        Debug.Log("Game Over!");
        gameTimerText.text = "Game Over!";
        turnTimerText.text = "";
        GameController.data.GameOver();
        //submitButton.interactable = false;
    }

    
}
