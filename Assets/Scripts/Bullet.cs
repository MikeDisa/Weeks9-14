using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;
    public Transform playerTransform;
    public SpriteRenderer playerRenderer;
    public SpriteRenderer mySpriteRenderer;

    float t = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        Debug.Log("player = " + player);
        Debug.Log("playerRenderer = " + playerRenderer);
        Debug.Log("mySpriteRenderer = " + mySpriteRenderer);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = (Vector2)transform.position + Vector2.down * t * Time.deltaTime;
        transform.position = newPosition;

        if (player == null || playerRenderer == null || mySpriteRenderer == null)
            return;

        Bounds biggerBounds = playerRenderer.bounds;
        biggerBounds.Expand(0.3f);

        if (mySpriteRenderer.bounds.Intersects(biggerBounds))
        {
            Debug.Log("hit");
            player.DamagePlayer(3);
            Destroy(gameObject);
        }


        if (transform.position.y < -8)
        {
            Destroy(gameObject);
        }
    }
}
