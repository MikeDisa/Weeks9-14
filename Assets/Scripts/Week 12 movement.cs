using NUnit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Week12movement : MonoBehaviour
{
    //public float speed = 5;
    public Vector2 movementTemp;
    public Vector2 movement;
    public Vector2 PlayerPos;

    public float t = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (movement != PlayerPos && movement != null)
        {
            transform.position = Vector2.Lerp(PlayerPos, movement, t);

            t += Time.deltaTime;
           
        }
    }


     public void OnPoint(InputAction.CallbackContext context)
    {
        movementTemp = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        PlayerPos = transform.position;
        movement = movementTemp;
        t = 0;
    }
}
