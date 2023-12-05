using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    public float moveSpeed;
    public float rotationSpeed;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
