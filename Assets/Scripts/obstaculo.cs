using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 2f;
    public float limit = 3f;
    public bool isHorizontal = false;

    private Rigidbody2D rb;
    private Vector2 startPosition;

    private Animator animator;
    private SpriteRenderer sprite;

    private Vector2 lastPosition;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        startPosition = transform.position;
        lastPosition = rb.position;
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

        direction = (newPosition - rb.position).normalized;

        rb.MovePosition(newPosition);
    }

    void Update()
    {
        bool isMoving = direction.sqrMagnitude > 0.01f;
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);

            if (direction.x > 0)
            {
                sprite.flipX = true;
            }
            else if (direction.x < 0)
            {
                sprite.flipX = false;
            }
        }
        else
        {
            animator.SetFloat("x", 0);
            animator.SetFloat("y", -1);
        }
    }
}