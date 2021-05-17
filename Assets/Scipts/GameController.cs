using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Score = 0;

    public int Lives = 3;

    public UIController UIController;

    public Ball Ball;

    public Vector3 BallResetPosition;

    private bool isPlaying = false;
    private bool isPaused = false;

    public void Start()
    {
        UIController.UpdateScoreText(Score);
        UIController.UpdateLives(Lives);

        PauseGame();
    }

    private void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            UnpauseGame();
        }

    }

    public void AddScore(int _value)
    {
        Score += _value;

        UIController.UpdateScoreText(Score);
    }

    public void BallLost()
    {
        // reset position
        Ball.transform.position = BallResetPosition;

        Vector3 currentVelocity = Ball.Velocity;
        currentVelocity.y = Mathf.Abs(currentVelocity.y);
        Ball.Velocity = currentVelocity;

        // lose life
        Lives--;
        UIController.UpdateLives(Lives);
        if (Lives < 0)
        {
            Debug.Log("Game Over!");
            GameOver();
        }
    }

    void GameOver()
    {
        UIController.ShowGameOver();
        isPlaying = false;
        PauseGame();
    }

    public void StartGame()
    {
        isPlaying = true;
        ResetGame();
        UnpauseGame();
    }

    void ResetGame()
    {
        Lives = 3;
        Score = 0;
        UIController.UpdateScoreText(Score);
        UIController.UpdateLives(Lives);
        UIController.HideStartGamePanel();
        UIController.HideGameOver();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;

        if (isPlaying)
        {
            UIController.ShowPausePanel();
        }
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        UIController.HidePausePanel();
    }

    public void QuitGame()
    {
        isPlaying = false;
        PauseGame();
        UIController.HideGameOver();
        UIController.HidePausePanel();
        UIController.ShowStartGamePanel();

        Ball.transform.position = BallResetPosition;
    }
}
