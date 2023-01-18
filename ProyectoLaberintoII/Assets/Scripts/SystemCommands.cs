using UnityEngine;
using UnityEngine.SceneManagement;

// Órdenes del sistema.
public class SystemCommands : MonoBehaviour
{
    // Sistema notificador de eventos.
    public delegate void command();
    public event command CloseDoor;

    // Audio controller
    public event command StartSong;

    // Sistema de gestión de animaciones.
    public Animator animator;

    // Objeto del que estará a la escucha el sistema.
    public PlayerController player;

    void Start()
    {
        player.Restart += Restarting;
        player.Complete += Completing;
    }

    void Update() { }

    // En caso de colisión con el jugador.
    void OnTriggerEnter(Collider collider)
    {
        if ((collider.gameObject.tag == "Player") && (gameObject.tag == "Entrada"))
        {
            CloseDoor();
            StartSong();
        }
    }

    // Reinicia la partida.
    void Restarting()
    {
        animator.SetTrigger("RestartTrigger");
    }

    // Función para preparar el segundo nivel.
    void Completing()
    {
        if (gameObject.tag == "Salida")
        {
            CloseDoor();
        }
    }

    // Función para cargar la escena de nuevo.
    void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
