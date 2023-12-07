using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEditor.AssetImporters;

public class GameManager : MonoBehaviour
{
    //Text 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    //Buttons
    public Button startButton;
    public Button restartButton;
    //Variables
    public int score;
    public int lives;
    public bool isGameActive;
    //Overall text objects for turning specific text on and off
    public GameObject startScreen;
    public GameObject changingText;
    public GameObject gameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        isGameActive = true;
        UpdateScore(0);
        UpdateLives(3);
        startScreen.SetActive(false);
        changingText.SetActive(true);
    }

    /* IEnumerator SpawnEnemy()
    {

    }*/

    // Update score with value from enemy destroyed
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int totalLives)
    {
        lives = 0;
        lives += totalLives;
        livesText.text = "Lives: " + lives;
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameActive = false;
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
