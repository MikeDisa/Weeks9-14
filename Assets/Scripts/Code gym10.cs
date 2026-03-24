using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Codegym10 : MonoBehaviour
{
    public Vector2 StartPos = Vector2.zero;
    public Vector2 EndPos = Vector2.zero;

    public float speed = 2f;

    bool isMoving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     transform.position = StartPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isMoving)
        {
            StartCoroutine(Driving(transform.position, EndPos));
        }
    }
    IEnumerator Driving(Vector2 start, Vector2 end)
    {
        isMoving = true;

        Vector2 direction = end - start;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle -90f);

        float time = 0f;
        float distance = Vector2.Distance(start, end);
        float duration = distance / speed;

        while (time < duration)
        {
            float t = time / duration;
            transform.position = Vector2.Lerp(start, end, t);

            time += Time.deltaTime;
            yield return null;
        }

        transform.position = end;

        isMoving = false;
    }
}
