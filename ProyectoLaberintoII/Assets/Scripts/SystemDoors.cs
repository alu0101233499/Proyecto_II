using UnityEngine;

// Sistema de cerrado de puertas.
public class SystemDoors : MonoBehaviour
{
    // Objeto del que estará a la escucha el sistema de compuertas.
    public SystemCommands system;

    private Rigidbody selfRigidbody;

    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
        system.CloseDoor += Close;
    }

    void Update()
    {}

    // Función para cerrar una puerta.
    void Close()
    {
        selfRigidbody.useGravity = true;
    }
}
