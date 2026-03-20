using System.Collections;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            StartCoroutine(Driving(transform.position, EndPos));
        }
    }
    IEnumerator Driving(Vector2 start, Vector2 end)
    {
        isMoving = true;
    }
}
