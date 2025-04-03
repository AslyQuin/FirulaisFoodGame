using System.Collections.Generic;
using UnityEngine;

public class InventarioNevera : MonoBehaviour
{
    private Queue<GameObject> objetosGuardados = new Queue<GameObject>(); // Cola de objetos almacenados

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("character_dog")) // Asegúrate de que el tag es correcto
        {
            Debug.Log("Personaje dentro de la ZonaNevera");
        }
    }

    public void GuardarObjeto(GameObject objeto)
    {
        objetosGuardados.Enqueue(objeto); // Guardar objeto en la cola
        objeto.SetActive(false); // Ocultarlo en la escena
        Debug.Log("Objeto guardado en la nevera: " + objeto.name);
    }

    public GameObject SacarObjeto()
    {
        if (objetosGuardados.Count > 0)
        {
            GameObject objeto = objetosGuardados.Dequeue();
            objeto.SetActive(true); // Hacerlo visible
            Debug.Log("Objeto recuperado de la nevera: " + objeto.name);
            return objeto;
        }
        else
        {
            Debug.Log("La nevera está vacía.");
            return null;
        }
    }
}