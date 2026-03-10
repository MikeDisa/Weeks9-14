using UnityEngine;
using UnityEngine.InputSystem;

public class Codegym9 : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public Vector3 rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        //I don't know what I'm doing
        //Vector3 newRotation = transform.eulerAngles;
        //newRotation.z += rotation.y * speed * Time.deltaTime;
        //transform.eulerAngles += (Vector3)movement * speed * Time.deltaTime;
        transform.eulerAngles = context.ReadValue<Vector2>();
    }
}
