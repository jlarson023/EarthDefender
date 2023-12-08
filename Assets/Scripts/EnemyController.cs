using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody enemyRb;
    //Array of different possible paths the enemy could take
    public GameObject[] enemyPaths;
    //random path in array variable
    private int randomPath;

    //X and Y positions for spawn
    //private float xMin = -13.0f;
    //private float yMin = -6.0f;
    //private float xMax = 13.0f;
    //private float yMax = 8.0f;

    //Other variables
    public float moveSpeed;
    public int pointValue;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //add each enemy path to the array
        for (int i = 0; i < enemyPaths.Length; i ++)
        {
            enemyPaths[i] = GameObject.Find($"EnemyPath{i}");
            Debug.Log("Each enemy path: " + enemyPaths[i]);
        }
        //The random path number(int) that will be assigned to the enemy prefab
        randomPath = Random.Range(0, enemyPaths.Length);
        Debug.Log("Random path: " + randomPath);
    }

    // Update is called once per frame
    void Update()
    {
        //the enemy will move in the direction of the random path assigned above
        /* if (gameManager.isGameActive)
        {
            Vector3 lookDirection = (enemyPaths[randomPath].transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * moveSpeed * Time.deltaTime);
        }  */

        if(gameManager.isGameActive)
        {
            Vector3 lookDirection = (enemyPaths[randomPath].transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * moveSpeed * Time.deltaTime);
        }

    }
}
