using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int hitPoints = 3;
    int block = 1;

    public float speed = 5;
    public Vector2 movement;

    public Vector2 currentPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(movement.x * speed * Time.deltaTime, 0f,0f);

        if (transform.position.x <= -11.55f)
        {
            transform.position = new Vector3 (-11.55f,currentPos.y,0f);
        }
       
        if (transform.position.x >= 11.55f)
        {
            transform.position = new Vector3 (11.55f,currentPos.y,0f);
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
        if (hitPoints == 0)
        {
            Debug.Log("hit");
        }
    }
}
