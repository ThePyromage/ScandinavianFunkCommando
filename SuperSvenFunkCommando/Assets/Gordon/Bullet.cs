using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    private bool canShoot = true;
    public float timeBetween = 0.2f;

    private void Update()
    {
        FireGun();
    }

    private void FireGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot)
            {
                GameObject GO = Instantiate(bullet, bulletSpawn.position, Quaternion.identity) as GameObject;
                GO.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
                Destroy(GO, 3);
                canShoot = false;
                Invoke("ResetShot", timeBetween);
            }
        }
    }  
    
    private void ResetShot()
    {
        canShoot = true;
    }
}
