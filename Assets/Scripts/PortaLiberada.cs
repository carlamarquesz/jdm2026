using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PortaLiberada : MonoBehaviour
{
    public int meninasNecessarias = 3;
    public string nomeDaProximaCena;
    public float tempoAntesDeTrocar = 1f;

    private Animator animator;
    private bool abriu = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !abriu)
        {
            if (SeguirPlayer.contadorMeninas >= meninasNecessarias)
            {
                abriu = true;
                StartCoroutine(AbrirPortaETrocarCena());
            }
            else
            {
                Debug.Log("Ainda falta encontrar amigas");
            }
        }
    }

    IEnumerator AbrirPortaETrocarCena()
    {
        animator.SetTrigger("abrir");
        yield return new WaitForSeconds(tempoAntesDeTrocar);
        SceneManager.LoadScene(nomeDaProximaCena);
    }
}
