using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public bool isMoving = false;

    private Rigidbody2D rb;
    private Vector2 move;

    private Health health; 

    private Animator animator;
    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
        Vector2 input = value.Get<Vector2>();

        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            move = new Vector2(input.x, 0);
        }
        else
        {
            move = new Vector2(0, input.y);
        }
    }

    public void Update() {
        isMoving = move.sqrMagnitude > 0.01;
        animator.SetBool("isMoving", isMoving);
        if (isMoving)
        {
            if (move.x > 0)
            {
                sprite.flipX = true;
            }
            else if (move.x < 0)
            {
                sprite.flipX = false;
            }
            animator.SetFloat("y", move.y);

        }
        else
        {
            animator.SetFloat("x", 0);
            animator.SetFloat("y", -1);

        }
        
        //animator.SetFloat("x", move.x);
       
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move * speed;
    }
    void OnCollisionEnter2D(Collision2D collision){

        
        if (collision.gameObject.CompareTag("Wall"))
        {
            
            Vector2 normal = collision.contacts[0].normal;
            rb.linearVelocity = Vector2.Reflect(rb.linearVelocity, normal);

        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            health.TakeDamage();
        }
    }
    
    


}