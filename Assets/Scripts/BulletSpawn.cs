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
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            Instantiate(bulletPrefab, spawnPoint.transform.position, bulletPrefab.transform.rotation);
        }
    }
}
