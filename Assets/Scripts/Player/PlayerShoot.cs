using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float projectileSpeed;
    public PlayerInventory inventoryScript;
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

            Projectile projectileScript = newProjectile.GetComponent<Projectile>();
            projectileScript.SetSpeed(projectileSpeed);
            projectileScript.inventoryScript = inventoryScript;
        }
    }
}
