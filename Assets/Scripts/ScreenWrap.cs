using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Rigidbody rb;
    public float rightBound = 11.0f;
    public float leftBound = -11.0f;
    public float topBound = 9.0f;
    public float bottomBound = -6.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if game object is past the right side of the screen and moving to the right (once I switch the player movement to add force)
        if (transform.position.x >= rightBound /*&& rb.velocity.x > 0*/)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        } //if game object is past the left side of the screen and moving to the left (once I switch the player movement to add force)
        else if (transform.position.x <= leftBound /*&& rb.velocity.x < 0*/)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }//if game object is past the top of the screen
        else if(transform.position.y >= topBound )
        {
            transform.position = new Vector3(transform.position.x, bottomBound, transform.position.z);
        }//if game object is past the bottom of the screen
        else if( transform.position.y <= bottomBound )
        {
            transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
        }
    }
}
