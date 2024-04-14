using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Press F to Restart")]

    public GameObject screenEndGame;

    [Header("Transform Paddle")]
    public Transform enemyPaddle;
    public Transform playerPaddle;

    [Header("Ball")]
    public BallControler ballControler;

    [Header("Win")]
    public int winPoints;

    private int playerScore = 0;
    private int enemyScore = 0;

    [Header("TextMesh")]
    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public TextMeshProUGUI textEndGame;



    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        playerPaddle.position = new Vector3(7f, 0f, 0f);
        enemyPaddle.position = new Vector3(-7f, 0f, 0f);

        ballControler.ResetBall();

        playerScore = 0;
        enemyScore = 0;
        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();

        screenEndGame.SetActive(false);

    }


    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }
    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            //ResetGame();
            EndGame();

        }
    }

    public void RestartGame()
    {
        if (Input.GetKey(KeyCode.F))
        {
            ResetGame();
        }
    }

    private void Update()
    {
        RestartGame();
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveControler.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Vitória " + winner;
        SaveControler.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
