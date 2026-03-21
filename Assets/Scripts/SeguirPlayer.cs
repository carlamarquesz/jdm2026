using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    public Transform alvo;
    public float speed = 3f;
    public float distanciaMinima = 1f;
    public static int contadorMeninas = 0; 
    private bool jaContado = false;



    private bool following = false;

    void Update()
    {
        if (following && alvo != null)
        {
            float distancia = Vector2.Distance(transform.position, alvo.position);

            if (distancia > distanciaMinima)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    alvo.position,
                    speed * Time.deltaTime
                );
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !jaContado)
        {
            following = true;
            contadorMeninas++;
            jaContado = true;
        }
        Debug.Log(contadorMeninas + "-" + jaContado);



    }
}