using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float moveSpeed;

    public GameObject smallUFO;

    public GameManager gameManager;

    private EnemyController enemyController;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyController = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive)
        {
            StartCoroutine(BulletBehavior());
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        /*if (collision.gameObject.CompareTag("Enemy"))
        {
            //int points = enemyController.pointValue;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(smallUFO, collision.gameObject.transform.position, smallUFO.transform.rotation);
            //Instantiate(smallUFO, collision.gameObject.transform.position, smallUFO.transform.rotation);
            //gameManager.UpdateScore(points);
        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            //int points = enemyController.pointValue;
            Destroy(gameObject);
            Destroy(collision.gameObject);

            //gameManager.UpdateScore(points);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //int points = enemyController.pointValue;
            gameManager.UpdateScore(50);
            Destroy(gameObject);
            Destroy(other.gameObject.transform.parent.gameObject);
            Instantiate(smallUFO, other.gameObject.transform.position, smallUFO.transform.rotation);
            Instantiate(smallUFO, other.gameObject.transform.position, smallUFO.transform.rotation);

            //gameManager.UpdateScore(points);
        } else if (other.gameObject.CompareTag("Enemy2"))
        {
            //int points = enemyController.pointValue;
            gameManager.UpdateScore(100);
            Destroy(gameObject);
            Destroy(other.gameObject.transform.parent.gameObject);
            //gameManager.UpdateScore(points);
        }
    }


    //Bullet moves and then gets destroyed after a specific amount of time
    IEnumerator BulletBehavior()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        //Destroy after 4 seconds
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

}
