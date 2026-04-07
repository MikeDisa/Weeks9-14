using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    //cross project asset plugin
    public UFO ufo;
    public Player player;
    public Transform playerTransform;
    public SpriteRenderer ufoRenderer;
    public SpriteRenderer mySpriteRenderer;

    //speed at which the shots travel
    float speed = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //grab the lower sprite for collision math
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        //Debug.Log("player = " + player);
        //Debug.Log("playerRenderer = " + ufoRenderer);
        //Debug.Log("mySpriteRenderer = " + mySpriteRenderer);
    }

    // Update is called once per frame
    void Update()
    {
        //moves the shot straight up
        Vector2 newPosition = (Vector2)transform.position + Vector2.up * speed * Time.deltaTime;
        transform.position = newPosition;
        //null protection
        if (ufo == null || ufoRenderer == null || mySpriteRenderer == null)
            return;
        //makes the hitbox bigger for easier colission
        Bounds biggerBounds = ufoRenderer.bounds;
        biggerBounds.Expand(0.3f);
        //sprite based hitboxes
        if (mySpriteRenderer.bounds.Intersects(biggerBounds))
        {
            //run damage function and destroy itself
            //Debug.Log("hit");
            ufo.DamageEnemy(1);
            Destroy(gameObject);
        }

        //destroy itself if it leaves the screen
        if (transform.position.y >= 8)
        {
            Destroy(gameObject);
        }
    }
}
