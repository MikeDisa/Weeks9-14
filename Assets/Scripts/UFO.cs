using System.Collections;
using UnityEngine;

public class UFO : MonoBehaviour
{
    //Hp and damage block
    public int hitPoints = 12;
    int block = 1;

    //keeps track of the game running or not
    public bool gameOn = true;

    //cross component plugin points
    public GameObject BulletPrefab;
    public GameObject MissilePrefab;
    public GameObject win;
    public Player player;
    public SpriteRenderer playerRenderer;
    //the ufo's main sprite
    public SpriteRenderer spriteRenderer;

    //gives the ufo invincibility frames
    public float Iframe = 2f;
    public float flashInterval = 0.1f;
    //co routine called flicker
    Coroutine flicker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {//coroutine that spams projectiles continuously
        StartCoroutine(SpawnBullet());
        StartCoroutine(SpawnMissile());

        //turns off UI element
        win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //who needs update?
    }

    //simple math that handles damage
    public void DamageEnemy(int dmg)
    {
        hitPoints = hitPoints - dmg * block;

        if (hitPoints <= 0)
        {
            //when hp reaches 0 game ends and co routines stop
            gameOn = false;

            StopCoroutine(SpawnBullet());
            StopCoroutine(SpawnMissile());

            win.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else if (block == 1)
        {//hit with remaining hp makes it flash 
            flicker = StartCoroutine(HitFlash());
        }
        }

    //spawn the small bullets each second
        IEnumerator SpawnBullet()
        {
            while (gameOn)
            {
                ShootBullet();

                yield return new WaitForSeconds(1);
            }
        }
    //invincibility coroutine
        IEnumerator HitFlash()
        {
            block = 0;

            float elapsed = 0f;

            while (elapsed < Iframe)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;

                yield return new WaitForSeconds(flashInterval);
                elapsed += flashInterval;
            }
            //flash by toggling renderer
            spriteRenderer.enabled = true;
            block = 1;
        }

    //the thing that handles the bullet prefab generation
        void ShootBullet()
        {
            if (BulletPrefab == null || player == null || playerRenderer == null)
            {
                //null protection
                return;
            }   //randomized x position but constant y
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
        { // spawns less often 
            while (gameOn)
            {
                SpawnProjectile();
                //So much debugging went into getting these to work
                // Debug.Log("Spawn Pos X"+ playerRenderer.bounds.center.x);
                //Debug.Log("Player Pos X"+ playerRenderer.transform.position.x);
                yield return new WaitForSeconds(3);
            }
        }
                //spawns in the same collem as the player for soft tracking
        void SpawnProjectile()
        {
            if (MissilePrefab == null || player == null || playerRenderer == null)
            {
                //Debug.LogWarning("Missile prefab or player references missing.");
                return;
            }

            // Use the player's current X position at the moment of spawn
            Vector2 spawnPosition = new Vector2(playerRenderer.bounds.center.x, 5f);
           

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

