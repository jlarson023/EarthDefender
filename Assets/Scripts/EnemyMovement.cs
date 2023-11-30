using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody enemyRb;
    public GameObject[] enemyPaths;
    private int randomPath;
    
    public float moveSpeed;
    //X and Y positions
    //private float xMin = -13.0f;
    //private float yMin = -6.0f;
    //private float xMax = 13.0f;
    //private float yMax = 8.0f;
    //Size of enemy variables
    //public float size = 1.0f;
    //public float minSize = 0.5f;
    //public float maxSize = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        
        /*for(i = 0; i < enemyPaths.Length; i ++)
        {
            enemyPaths[i] = GameObject.Find($"EnemyPath{i}");
        } */ //add each enemy path to the array

        randomPath = Random.Range(0, enemyPaths.Length);
        Debug.Log("Random path: " + randomPath);
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 lookDirection = (enemyPaths[randomPath].transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * moveSpeed * Time.deltaTime);
    }

}
