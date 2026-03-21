using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{   
    private PlayerInput playerInput;
    private InputAction restartAction;

    void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        restartAction = playerInput.actions["Restart"];
    }

    void Update()
    {
        if (restartAction != null && restartAction.WasPressedThisFrame())
        {
            Debug.Log("Reiniciando...");

            Time.timeScale = 1f; // 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}