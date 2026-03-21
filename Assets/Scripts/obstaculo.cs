using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 2f;
    public float limit = 3f;

    public bool isHorizontal = false; //  controla direção

    private Rigidbody2D rb;
    private Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        float movement = Mathf.PingPong(Time.time * speed, limit * 2) - limit;

        Vector2 newPosition;

        if (isHorizontal)
        {
            newPosition = new Vector2(startPosition.x + movement, startPosition.y);
        }
        else
        {
            newPosition = new Vector2(startPosition.x, startPosition.y + movement);
        }

        rb.MovePosition(newPosition);
    }
}