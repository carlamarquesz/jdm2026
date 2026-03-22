using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCenaPorMeninas : MonoBehaviour
{
    public int meninasNecessarias = 3;
    public string nomeDaCena;
    public float delay = 1f;

    private bool jaTrocou = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !jaTrocou)
        {
            if (GameManager.instance.contadorMeninas >= meninasNecessarias)
            {
                jaTrocou = true;
                Invoke(nameof(TrocarCena), delay);
            }
            else
            {
                Debug.Log("Você ainda não tem meninas suficientes!");
            }
        }
    }   

    public void TrocarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}