using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header("Vida do Player")]
    [SerializeField] private int life = 3;
    [SerializeField] private bool canTakeDamage = true;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOver;

    [Header("Configuração")]
    [SerializeField] private float damageCooldown = 0.3f;
    [SerializeField] private GameObject[] moedas;

    private Rigidbody2D rb;
    private bool dieOnce = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameOver != null)
        {
            gameOver.SetActive(false); // começa escondido
        }
    }

    public void TakeDamage()
    {
        if (!canTakeDamage || !dieOnce) return;

        canTakeDamage = false;
        StartCoroutine(DamageCooldown());

        life--;
        AtualizarMoedas();


        if (life <= 0)
        {
            Die();
        }
    }

    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }

    void Die()
    {
        if (!dieOnce) return;

        dieOnce = false;

        rb.linearVelocity = Vector2.zero;
        GetComponent<PlayerMove>().enabled = false;

        if (gameOver != null)
        {
            gameOver.SetActive(true);
        }

        Time.timeScale = 0f;
    }
    void AtualizarMoedas()
    {
        for (int i = 0; i < moedas.Length; i++)
        {
            if (i < life)
            {
                moedas[i].SetActive(true); 
            }
            else
            {
                moedas[i].SetActive(false); 
            }
        }
    }
}