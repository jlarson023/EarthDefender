using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody enemyRb;
    public float moveSpeed = 3.0f;

    //public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Vector3 direction = Random.insideUnitCircle.normalized;
        enemyRb.AddForce(moveSpeed * direction, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {


    }
}
