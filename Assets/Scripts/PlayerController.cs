using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Rigidbody playerRb;
    
    private float verticalInput;
    private float horizontalInput;
    public float moveSpeed;
    public float rotationSpeed;
    //audio
    public AudioClip booster;
    private AudioSource playerAudio;
    //Particle system
    public ParticleSystem boosterParticle;

    public GameManager gameManager;

    private int totalLives;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = gameManager.GetComponent<AudioSource>();
        //playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
        }

        /*if (verticalInput > 0)
        {
            playerAudio.PlayOneShot(booster, 0.6f);
            boosterParticle.Play();
        }*/

            totalLives = gameManager.lives;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2"))
        {
            if(totalLives == 0)
            {
                gameManager.GameOver();
            }
            else
            {
                //destroy player
                Destroy(gameObject);
                //lose a life
                gameManager.UpdateLives(totalLives - 1);
                //spawn new player
                gameManager.PlayerSpawn();
            }
        }
    }*/


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2"))
        {
            if(totalLives == 0)
            {
                gameManager.GameOver();
            }
            else
            {
                //destroy player
                Destroy(gameObject);
                //lose a life
                gameManager.UpdateLives(totalLives - 1);
                //spawn new player
                gameManager.PlayerSpawn();
            }
        }
    }
}
