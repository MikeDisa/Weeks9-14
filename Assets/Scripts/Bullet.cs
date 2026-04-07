using UnityEngine;

public class Bullet : MonoBehaviour
{
    //cross project pluggin slots
    public Player player;
    public Transform playerTransform;
    public SpriteRenderer playerRenderer;
    public SpriteRenderer mySpriteRenderer;

    //speed at which bullets fly
    float speed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get lower sprite renderer for bounds collision
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        //Debug.Log("player = " + player);
        //Debug.Log("playerRenderer = " + playerRenderer);
        //Debug.Log("mySpriteRenderer = " + mySpriteRenderer);
    }

    // Update is called once per frame
    void Update()
    {       //moves the bullet straight down
        Vector2 newPosition = (Vector2)transform.position + Vector2.down * speed * Time.deltaTime;
        transform.position = newPosition;

        if (player == null || playerRenderer == null || mySpriteRenderer == null)
            return;
        //makes the bounds bigger for easier collision
        Bounds biggerBounds = playerRenderer.bounds;
        biggerBounds.Expand(0.3f);

        //sprite based hitboxes
        if (mySpriteRenderer.bounds.Intersects(biggerBounds))
        {
            //run damage and then blow up
            //Debug.Log("hit");
            player.DamagePlayer(3);
            Destroy(gameObject);
        }


        if (transform.position.y < -8)
        {//blow up once leaving screen
            Destroy(gameObject);
        }
    }
}
