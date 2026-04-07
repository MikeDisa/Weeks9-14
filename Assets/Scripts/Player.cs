using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //player hp and shield multiplier
    public int hitPoints = 3;
    public int block = 1;

    //controls player's rate of fire
    public float fireCooldown = 1.5f;
    float nextFireTime = 0f;

    //vector and 
    public float speed = 5;
    public Vector2 movement;

    public Vector2 currentPos;

    public GameObject PlayerShotPrefab;
    public GameObject Shield;
    public UFO ufo;
    public SpriteRenderer UfoRenderer;

    public GameObject lose;

    public Shieldfunction shield;

    public UnityEvent onAttackEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        currentPos = transform.position;

        if (onAttackEvent == null)
        {
            onAttackEvent = new UnityEvent();
        }
        onAttackEvent.RemoveListener(FireShot);
        onAttackEvent.AddListener(FireShot);

        lose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;

        transform.position += new Vector3(movement.x * speed * Time.deltaTime, 0f, 0f);

        if (transform.position.x <= -11.55f)
        {
            transform.position = new Vector3(-11.55f, currentPos.y, 0f);
        }

        if (transform.position.x >= 11.55f)
        {
            transform.position = new Vector3(11.55f, currentPos.y, 0f);
        }
        //transform.position = new Vector2 (movement.x,transform.position.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }


    public void DamagePlayer(int dmg)
    {
        hitPoints = hitPoints - dmg * block;
        if (hitPoints <= 0)
        {
            ufo.gameOn = false;
            lose.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onAttackEvent.Invoke();
        }
    }

    public void FireShot()
    {
        if (Time.time < nextFireTime)
        {
            return;
        }

        nextFireTime = Time.time + fireCooldown;

        if (PlayerShotPrefab == null || ufo == null || UfoRenderer == null)
        {
            return;
        }

        Vector2 offset = new Vector2(currentPos.x + 1, currentPos.y + 3);
        GameObject newProjectile = Instantiate(PlayerShotPrefab, offset, Quaternion.identity);

        // Get the projectile script from the spawned prefab
        PlayerShot shotScript = newProjectile.GetComponent<PlayerShot>();

        if (shotScript != null)
        {
            shotScript.ufo = ufo;
            shotScript.ufoRenderer = UfoRenderer;

        }
    }

    public void OnShield(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            Debug.Log("click" + context.phase);
            shield.gameObject.SetActive(true);
            block = 0;
            onAttackEvent.RemoveListener(FireShot);
        }

        if (context.canceled)
        {
            Debug.Log("click" + context.phase);
            block = 1;
            shield.gameObject.SetActive(false);
            onAttackEvent.RemoveListener(FireShot);
            onAttackEvent.AddListener(FireShot);
        }
    }
}
