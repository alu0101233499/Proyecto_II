using UnityEngine;

// Importante, realizar un cartel de instrucciones que será accesible pintandolo
// en la pared con la i.

// Controlador de personaje e interacciones con el entorno.
public class PlayerController : MonoBehaviour
{
    // Sistema notificador de eventos.
    public delegate void command();
    public event command Restart;
    public event command Complete;

    // AUDIO CONTROLLER
    public event command MidSong;
    public event command EndSong;
    private AudioSource source;

    // Booleano de movimiento
    private bool isMoving;

    // Raycast para saber donde está mirando el jugador.
    private RaycastHit ray;

    // Pintura.
    public GameObject paint;

    // Controlador de personaje.
    private CharacterController controller;

    // Cámara principal.
    private Camera mainCamera;

    // Vectores de movimiento.
    private Vector3 movement,
        fall;

    // Contador por cristal
    private int blueObject,
        redObject,
        greenObject;

    // Velocidades de movimiento.
    private float movementSpeed,
        rotationSpeed,
        gravityForce;

    // Variables auxiliares para la rotación y el movimiento.
    private float pitch,
        yaw,
        directionY;

    private bool isActiveCrystals,
        isActiveExitTheLabyrinth;

    void Start() // IEnumerator
    {
        // Cursor invisible.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Obtención del controlador de personaje y la cámara.
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;

        // Establece las velocidades.
        movementSpeed = 6f;
        rotationSpeed = 600f;
        gravityForce = 2f;

        // Establece las variables auxiliares de movimiento y rotación.
        pitch = 0f;
        yaw = 0f;
        directionY = 0;

        // Establece los coleccionables a 0.
        blueObject = 0;
        redObject = 0;
        greenObject = 0;

        // Asignamos las musicas a false
        isActiveCrystals = false;
        isActiveExitTheLabyrinth = false;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 forward = mainCamera.transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(mainCamera.transform.position, forward, Color.green);

        // Función de pintura.
        if (
            (Physics.Raycast(mainCamera.transform.position, forward, out ray))
            && (Input.GetButtonDown("Fire1"))
        )
        {
            Instantiate(paint, ray.point, paint.transform.rotation);
        }

        // Función de movimiento por defecto.
        Move();

        if (isMoving && !source.isPlaying)
        {
            source.Play();
        }
        else if (!isMoving && source.isPlaying)
        {
            source.Stop();
        }

        // Función de rotación por defecto.
        Rotate();

        // Función de reinicio en la tecla M.
        if (Input.GetButtonDown("Restart"))
            Restart();

        // Función de gravedad.
        Fall();

        // Si se han recogido 8 cristales
        if (!isActiveCrystals && (blueObject + greenObject + redObject) == 8)
        {
            isActiveCrystals = true;
            MidSong();
        }
        // Si se han recogido 15 cristales se activa la música final
        if (!isActiveExitTheLabyrinth && (blueObject + greenObject + redObject) == 15)
        {
            isActiveExitTheLabyrinth = true;
            EndSong();
        }
    }

    // Permite el movimiento con las teclas WS (Arriba-Abajo) y AD
    // (Izquierda-Derecha).
    void Move()
    {
        // Obtención de los valores de movimiento y normalización.
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = Vector3.ClampMagnitude(movement, 1);

        if (movement.magnitude != 0)
        {
            source.loop = true;
            isMoving = true;
        }
        else
        {
            isMoving = false;
            source.loop = false;
        }

        // Transformación del movimiento respecto al sistema de coordenadas
        // global.
        Vector3 transformedMovement = mainCamera.transform.TransformDirection(
            movement * movementSpeed
        );

        // Movimiento.
        controller.Move(transformedMovement * Time.deltaTime);
    }

    // Permite la rotación con el ratón.
    void Rotate()
    {
        // Obtención de los valores de rotación.
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotationSpeed;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rotationSpeed;

        // Obtención del aumento del cabeceo y guiñada.
        yaw = yaw + mouseX;
        pitch = pitch - mouseY;

        // Limitación del cabeceo para mejorar el confort en RV.
        pitch = Mathf.Clamp(pitch, -25f, 25f);

        // Rotación suavizada de la cámara y el jugador.
        mainCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }

    // Permite aplicar la fuerza de la gravedad.
    void Fall()
    {
        fall = new Vector3(0, 0, 0);
        directionY = directionY - (gravityForce * Time.deltaTime);
        fall.y = directionY;

        // Caída.
        controller.Move(fall * Time.deltaTime);
    }

    // Colisiones con objetos varios.
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Azul")
            blueObject++;
        if (collider.gameObject.tag == "Rojo")
            redObject++;
        if (collider.gameObject.tag == "Verde")
            greenObject++;

        if (collider.gameObject.tag == "Salida")
        {
            if ((blueObject == 5) && (redObject == 5) && greenObject == 5)
            {
                Complete();
            }
        }
    }
}
