using UnityEngine;
using UnityEngine.InputSystem;


public class LocalMulitplayerControler : MonoBehaviour
{
    public LocalMutltiplayermanager manager;
    public PlayerInput playerInput;
    public Vector2 movementInput;
    public float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            Debug.Log("Player" + playerInput.playerIndex + ": teriyakki");
            manager.PlayerAttacking(playerInput);
        }
    }

   

}

