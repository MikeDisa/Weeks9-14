using System.Collections;
using UnityEngine;

public class UFO : MonoBehaviour
{
    int hitPoints = 12;
    int block = 1;

    public bool gameOn = true;

    public GameObject BulletPrefab;
    public GameObject MissilePrefab;
    public Player player;
    public SpriteRenderer playerRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBullet());
        StartCoroutine(SpawnMissile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(int dmg)
    {
        hitPoints = hitPoints - dmg * block;

        if (hitPoints <= 0) 
        { 
            gameOn = false;
           
                StopCoroutine(SpawnBullet());
                StopCoroutine(SpawnMissile());
        }
    }

    IEnumerator SpawnBullet()
    {
        while (gameOn)
        {
            ShootBullet();

            yield return new WaitForSeconds(1);
        }
    }

    void ShootBullet()
    {
        if (BulletPrefab == null || player == null || playerRenderer == null)
        {
            //Debug.LogWarning("Projectile prefab or player references missing.");
            return;
        }
        float randomX = UnityEngine.Random.Range(-11f, 11f);
        Vector2 spawnPosition = new Vector2(randomX, 5f);

        GameObject newProjectile = Instantiate(BulletPrefab, spawnPosition, Quaternion.identity);

        // Get the projectile script from the spawned prefab
        Bullet bulletScript = newProjectile.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.player = player;
            bulletScript.playerRenderer = playerRenderer;
        }
    }
    IEnumerator SpawnMissile()
    {
        while (gameOn)
        {
            SpawnProjectile();
           // Debug.Log("Spawn Pos X"+ playerRenderer.bounds.center.x);
            //Debug.Log("Player Pos X"+ playerRenderer.transform.position.x);
            yield return new WaitForSeconds(3);
        }
    }

    void SpawnProjectile()
    {
        if (MissilePrefab == null || player == null || playerRenderer == null)
        {
            //Debug.LogWarning("Missile prefab or player references missing.");
            return;
        }

        // Use the player's current X position at the moment of spawn
        Vector2 spawnPosition = new Vector2(playerRenderer.bounds.center.x, 5f);
        //Vector2 spawnPosition = new Vector2(player.currentPos.x, 5);

        GameObject newProjectile = Instantiate(MissilePrefab, spawnPosition, Quaternion.identity);

        // Get the projectile script from the spawned prefab
        Missile missileScript = newProjectile.GetComponent<Missile>();

        if (missileScript != null)
        {
            missileScript.player = player;
            missileScript.playerRenderer = playerRenderer;
        }
    }
}
