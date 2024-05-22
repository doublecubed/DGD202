using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float projectileSpeed;
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

            Projectile projectileScript = newProjectile.GetComponent<Projectile>();
            projectileScript.SetSpeed(projectileSpeed);
        }
    }
}
