using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * horizontalInput * Time.deltaTime);
    }
}
