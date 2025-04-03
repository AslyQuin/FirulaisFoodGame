using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform hand; // Referencia a la mano del jugador
    private GameObject heldObject = null; // Objeto que se sostiene en la mano

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Presiona "E" para recoger o soltar
        {
            if (heldObject == null)
            {
                TryPickUp(); // Si no hay objeto en la mano, intenta agarrar uno
            }
            else
            {
                DropObject(); // Si ya hay un objeto en la mano, suéltalo
            }
        }
    }

    void TryPickUp()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, 2f); // Detecta objetos cercanos
        foreach (Collider obj in objects)
        {
            if (obj.CompareTag("Pickable")) // Si el objeto es "Pickable"
            {
                heldObject = obj.gameObject;
                heldObject.transform.SetParent(hand); // Se asigna a la mano
                heldObject.transform.localPosition = Vector3.zero;
                heldObject.transform.localRotation = Quaternion.identity;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Desactiva la física
                Debug.Log("Objeto recogido: " + heldObject.name);
                return; // Sale después de recoger un objeto
            }
        }
    }

    public void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
            Debug.Log("Objeto soltado.");
        }
    }

    // ✅ NUEVAS FUNCIONES PARA INTERACTUAR CON LA NEVERA

    public GameObject GetHeldObject()
    {
        return heldObject;
    }

    public void EliminarObjetoDeLaMano()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
            Debug.Log("Objeto eliminado de la mano.");
        }
    }

    public void RecogerObjetoDesdeNevera(GameObject objeto)
    {
        if (objeto != null)
        {
            heldObject = objeto;
            heldObject.transform.SetParent(hand);
            heldObject.transform.localPosition = Vector3.zero;
            heldObject.transform.localRotation = Quaternion.identity;
            heldObject.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Objeto tomado de la nevera: " + heldObject.name);
        }
    }
}