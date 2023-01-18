using UnityEngine;

public class ObjectShine : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Colisiones con objetos varios.
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Disappear();
        }
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }
}
