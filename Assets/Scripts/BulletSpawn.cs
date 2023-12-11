using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject bulletPrefab;
    public bool canShoot = true;
    public float shootDelay = 0.5f;

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Controller shooting
        if (Input.GetButtonDown("Shoot") && gameManager.isGameActive && canShoot)
        {
            Debug.Log("You pressed shoot.");
            StartCoroutine(Shoot());
            
        }
        //Keyboard shooting
        if (Input.GetKeyDown(KeyCode.E) && gameManager.isGameActive && canShoot) 
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        //Shoot bullet
        Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        //Wait for a specific amount of time then be able to shoot again
        yield return new WaitForSeconds(shootDelay);

        canShoot = true;
    }
}
