using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int contadorMeninas = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}