using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 move;
    
    

    private Health health; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move * speed;
    }
    void OnCollisionEnter2D(Collision2D collision){

        
        if (collision.gameObject.CompareTag("Wall"))
        {
            
            Vector2 normal = collision.contacts[0].normal;
            rb.velocity = Vector2.Reflect(rb.velocity, normal);

        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            health.TakeDamage();
        }
    }
    
    


}