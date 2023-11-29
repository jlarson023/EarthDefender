using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject bulletPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Controller shooting
        if (Input.GetButtonDown("Shoot"))
        {
            Debug.Log("You pressed shoot.");
            Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        //Keyboard shooting
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }
}
