using UnityEngine;

public class InventarioNevera : MonoBehaviour
{
    public GameObject mensajeTexto; // Arrastra el objeto de texto aquí en el Inspector
    private bool jugadorCerca = false; // Variable para detectar al jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("character_dog"))
        {
            jugadorCerca = true;
            mensajeTexto.SetActive(true); // Mostrar mensaje
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("character_dog"))
        {
            jugadorCerca = false;
            mensajeTexto.SetActive(false); // Ocultar mensaje
        }
    }
}

