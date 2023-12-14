using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject bulletPrefab;
    public bool canShoot = true;
    public float shootDelay = 0.5f;
    //Audio
    private AudioSource laserAudio;
    public AudioClip laser;

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        laserAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Controller shooting
        if (Input.GetButtonDown("Shoot") && gameManager.isGameActive && canShoot)
        {
            Debug.Log("You pressed shoot.");
            StartCoroutine(Shoot());
            laserAudio.PlayOneShot(laser, 0.6f);
            
        }
        //Keyboard shooting
        if (Input.GetKeyDown(KeyCode.E) && gameManager.isGameActive && canShoot) 
        {
            StartCoroutine(Shoot());
            laserAudio.PlayOneShot(laser, 0.6f);
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
