using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted = false;
    public GameObject player;
    public TMPro.TextMeshProUGUI livesText;
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject menu;
    public GameObject gameplayUI;
    public GameObject spawner;
    public GameObject background;

    int lives = 3;
    int score = 0;
    Vector3 originalCameraPosition;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalCameraPosition = Camera.main.transform.position;
    }

    public void StartGame()
    {
        gameStarted = true;

        menu.SetActive(false);
        gameplayUI.SetActive(true);
        spawner.SetActive(true);
        background.SetActive(true);
    }

    public void GameOver()
    {
        player.SetActive(false);

        Invoke("Restart", 1.5f);
    }

    public void Restart() 
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateLives()
    {
        if(lives <= 0)
        {
            GameOver();
        }
        else
        {
            lives--;

            livesText.text = "Lives " + lives;
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score " + score;
    }

    public void Shake()
    {
        StartCoroutine("CameraShake");
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator CameraShake()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * 0.5f;

            Camera.main.transform.position = new Vector3(randomPosition.x, randomPosition.y, originalCameraPosition.z);

            yield return null;
        }

        Camera.main.transform.position = originalCameraPosition;
    }
}
