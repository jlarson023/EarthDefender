using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
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
    //prefabs
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    //spawns
    public GameObject playerSpawnPos;
    public GameObject[] enemySpawns;
    //Wave variables
    public int ufoCount = 0;
    public int level = 0;
    //X and Y positions for spawn
    //private float xMin = -13.0f;
    //private float yMin = -6.0f;
    //private float xMax = 13.0f;
    //private float yMax = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        //add each enemyspawn to the array
        for (int i = 0; i < enemySpawns.Length; i++)
        {
            enemySpawns[i] = GameObject.Find($"Spawner{i}");
            //Debug.Log("Each enemy spawn: " + enemySpawns[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ufoCount = FindObjectsOfType<EnemyController>().Length;
        if (isGameActive)
        {
            //if there are no ufos left spawn more
            if (ufoCount == 0)
            {
                //increase level
                level++;
                //increase number of UFOs
                int numUFOs = 1 + (1 * level);
                SpawnEnemyWave(numUFOs);
            }
        }
    }

    public void StartGame()
    {
        isGameActive = true;

        PlayerSpawn();
        //SpawnEnemyWave(2);
        UpdateScore(0);
        UpdateLives(3);
        startScreen.SetActive(false);
        changingText.SetActive(true);
    }

    // Update score with value from enemy destroyed
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    //Update player lives
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

    public void PlayerSpawn()
    {
        Instantiate(playerPrefab, playerSpawnPos.transform.position, playerPrefab.transform.rotation);
    }

    public void SpawnEnemy()
    {
        //Instantiate(enemyPrefab, GenerateEnemySpawn(), enemyPrefab.transform.rotation);
        GameObject spawnPoint = enemySpawns[UnityEngine.Random.Range(0, enemySpawns.Length)];
        //Debug.Log("SpawnPoint: " + spawnPoint.name);
        Instantiate(enemyPrefab, spawnPoint.transform.position, enemyPrefab.transform.rotation);
    }

    /*private Vector3 GenerateEnemySpawn()
    {
        float spawnPosY = Random.Range(yMin, yMax);
        float spawnPosX = Random.Range(xMin, xMax);

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }*/

    void SpawnEnemyWave(int numUFOs)
    {
        for (int i = 0; i < numUFOs; i++)
        {
            SpawnEnemy();
        }
    }
}
