using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Player player;
    public Transform playerTransform;
    public SpriteRenderer playerRenderer;
    public SpriteRenderer mySpriteRenderer;

    Vector2 direction;
    float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        direction = Vector2.down;

        //Debug.Log("Missile Pos" + transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;
        transform.position = newPosition;

        if(player == null || playerRenderer == null || mySpriteRenderer == null)
            return;

        Bounds biggerBounds = playerRenderer.bounds;
        biggerBounds.Expand(0.3f);

        if (mySpriteRenderer.bounds.Intersects(biggerBounds))
        {
            //Debug.Log("hit");
            player.DamagePlayer(3);
            //Debug.Log("Missile end Pos" + transform.position);
            Destroy(gameObject);
        }

        if (transform.position.y < -8)
        {
           // Debug.Log("Missile end Pos" + transform.position);
            Destroy(gameObject);
        }
    }

    
}
