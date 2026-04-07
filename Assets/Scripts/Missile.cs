using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Missile : MonoBehaviour
{
    //cross object plugin slots
    public Player player;
    public Transform playerTransform;
    public SpriteRenderer playerRenderer;
    public SpriteRenderer mySpriteRenderer;

    //activates travel direction and the speed
    Vector2 direction;
    float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //grabds the lower object's sprite render for bounds
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        direction = Vector2.down;

        //Debug.Log("Missile Pos" + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //just moves the missile in a straight line down
        Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;
        transform.position = newPosition;

        if(player == null || playerRenderer == null || mySpriteRenderer == null)
            return;
        //made the hitbox bigger to help colision
        Bounds biggerBounds = playerRenderer.bounds;
        biggerBounds.Expand(0.3f);

        //sprite based hitbox colision
        if (mySpriteRenderer.bounds.Intersects(biggerBounds))
        {
            //runs damage math and then blows up
            //Debug.Log("hit");
            player.DamagePlayer(3);
            //Debug.Log("Missile end Pos" + transform.position);
            Destroy(gameObject);
        }

        if (transform.position.y < -8)
        {
            //if it leaves the screen blows up
           // Debug.Log("Missile end Pos" + transform.position);
            Destroy(gameObject);
        }
    }

    
}
