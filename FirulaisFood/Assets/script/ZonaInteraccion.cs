using UnityEngine;

public class ZonaInteraccion : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        // Verifica si el jugador está dentro de la zona
        if (other.CompareTag("Player"))
        {
            PickUpObject pickUpScript = other.GetComponent<PickUpObject>();
            InventarioNevera nevera = FindFirstObjectByType<InventarioNevera>();

            if (pickUpScript == null || nevera == null) return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Si el jugador tiene un objeto en la mano, lo guarda en la nevera
                GameObject objetoEnMano = pickUpScript.GetHeldObject();
                if (objetoEnMano != null)
                {
                    nevera.GuardarObjeto(objetoEnMano);
                    pickUpScript.EliminarObjetoDeLaMano(); // Libera la mano del jugador
                    Debug.Log("Objeto guardado en la nevera: " + objetoEnMano.name);
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                // Si el jugador NO tiene un objeto en la mano, saca uno de la nevera
                if (pickUpScript.GetHeldObject() == null)
                {
                    GameObject objetoRecuperado = nevera.SacarObjeto();
                    if (objetoRecuperado != null)
                    {
                        pickUpScript.RecogerObjetoDesdeNevera(objetoRecuperado);
                        Debug.Log("Objeto recuperado de la nevera: " + objetoRecuperado.name);
                    }
                    else
                    {
                        Debug.Log("No hay objetos en la nevera.");
                    }
                }
            }
        }
    }
}
