using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    public Transform meuAlvo;
    public float speed = 3f;
    public float distanciaMinima = 1f;

    private bool jaContado = false;
    private bool following = false;

    private Animator anim;
    private SpriteRenderer sprite;

    public GameObject GameManagerObject;


    private Vector2 ultimaDirecao = Vector2.down;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (following && meuAlvo != null)
        {
            Vector2 diferenca = meuAlvo.position - transform.position;
            float distancia = diferenca.magnitude;

            if (distancia > distanciaMinima)
            {
                Vector2 direcao = diferenca.normalized;

                transform.position = Vector2.MoveTowards(
                    transform.position,
                    meuAlvo.position,
                    speed * Time.deltaTime
                );

                Vector2 direcaoAnim;

                if (Mathf.Abs(direcao.x) > Mathf.Abs(direcao.y))
                {
                    direcaoAnim = new Vector2(1f, 0f);

                    if (direcao.x < 0)
                        sprite.flipX = false;
                    else
                        sprite.flipX = true;
                }
                else
                {
                    direcaoAnim = new Vector2(0f, Mathf.Sign(direcao.y));
                }

                ultimaDirecao = direcaoAnim;

                anim.SetFloat("x", direcaoAnim.x);
                anim.SetFloat("y", direcaoAnim.y);
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
                anim.SetFloat("x", ultimaDirecao.x);
                anim.SetFloat("y", ultimaDirecao.y);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !jaContado)
        {
            following = true;
            GameManagerObject.GetComponent<GameManager>().contadorMeninas++;
            jaContado = true;
            meuAlvo = GameManagerObject.GetComponent<GameManager>().alvo;
            GameManagerObject.GetComponent<GameManager>().alvo = transform;
            Debug.Log("Meninas: " + GameManagerObject.GetComponent<GameManager>().contadorMeninas);

            if (GameManagerObject.GetComponent<GameManager>().contadorMeninas >= 3)
            {
                DestruirPortas();
            }
        }
    }

    void DestruirPortas()
    {
        GameObject[] portas = GameObject.FindGameObjectsWithTag("Porta");

        foreach (GameObject porta in portas)
        {
            Destroy(porta);
        }
    }
}