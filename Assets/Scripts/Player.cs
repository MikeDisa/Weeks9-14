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

    //holds the player's current location in a static location
    public Vector2 currentPos;

    //cross script hookups
    public GameObject PlayerShotPrefab;
    public GameObject Shield;
    public UFO ufo;
    public SpriteRenderer UfoRenderer;

    //the lose UI element
    public GameObject lose;

    //shield hookup
    public Shieldfunction shield;

    //the code driven unity event
    public UnityEvent onAttackEvent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gets position for targeting
        currentPos = transform.position;

        //hooks up the player's cannon with code
        if (onAttackEvent == null)
        {
            onAttackEvent = new UnityEvent();
        }
        //removing listeners takes care of any weirdness so that going on is clean
        onAttackEvent.RemoveListener(FireShot);
        onAttackEvent.AddListener(FireShot);

        //turns off UI element
        lose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //updates the static pos holder
        currentPos = transform.position;

        //updates the player as the input changes a thing
        transform.position += new Vector3(movement.x * speed * Time.deltaTime, 0f, 0f);

        //boundry constraints
        if (transform.position.x <= -11.55f)
        {
            transform.position = new Vector3(-11.55f, currentPos.y, 0f);
        }

        if (transform.position.x >= 11.55f)
        {
            transform.position = new Vector3(11.55f, currentPos.y, 0f);
        }
        
    }

    //it's the movement input
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    //basic math for updating the hp
    public void DamagePlayer(int dmg)
    {
        hitPoints = hitPoints - dmg * block;
        if (hitPoints <= 0)
        { //when hp = 0 the player disapears and ui appears
            ufo.gameOn = false;
            lose.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    //On click fires the player's weapon
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onAttackEvent.Invoke();
        }
    }
    //player's cannon code
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
        //the part that spawns the player's shots
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
    //blocks damage
    public void OnShield(InputAction.CallbackContext context)
    {
        // if it gets stuck, switch UI left click to a button

        //on click zero out damage and show shield sprite and disconect weapon
        if (context.performed)
        {
            Debug.Log("click" + context.phase);
            shield.gameObject.SetActive(true);
            block = 0;
            onAttackEvent.RemoveListener(FireShot);
        }
        //on release revert damage and hide shield and reconect weapon
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
