using NUnit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Week12movement : MonoBehaviour
{
    //public float speed = 5;
    public Vector2 movement;
    public Vector2 PlayerPos;

    public int t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        while (movement != PlayerPos)
        {
            transform.position = Vector2.Lerp(PlayerPos, movement, t);

            t += (int)Time.deltaTime;
        }
    }

     public void OnPoint(InputAction.CallbackContext context)
    {
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
