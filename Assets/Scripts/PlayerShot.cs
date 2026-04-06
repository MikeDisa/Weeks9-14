using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public UFO ufo;
    public Player player;
    public Transform playerTransform;
    public SpriteRenderer ufoRenderer;
    public SpriteRenderer mySpriteRenderer;

    float speed = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        //Debug.Log("player = " + player);
        //Debug.Log("playerRenderer = " + ufoRenderer);
        //Debug.Log("mySpriteRenderer = " + mySpriteRenderer);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = (Vector2)transform.position + Vector2.up * speed * Time.deltaTime;
        transform.position = newPosition;

        if (ufo == null || ufoRenderer == null || mySpriteRenderer == null)
            return;

        Bounds biggerBounds = ufoRenderer.bounds;
        biggerBounds.Expand(0.3f);

        if (mySpriteRenderer.bounds.Intersects(biggerBounds))
        {
            //Debug.Log("hit");
            ufo.DamageEnemy(1);
            Destroy(gameObject);
        }


        if (transform.position.y >= 8)
        {
            Destroy(gameObject);
        }
    }
}
