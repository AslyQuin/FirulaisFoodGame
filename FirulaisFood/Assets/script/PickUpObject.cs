using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform hand; // Referencia al punto donde se sostiene el objeto
    private GameObject heldObject = null; // Objeto que está siendo sostenido

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Cambia la tecla si quieres otra
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
        Collider[] objects = Physics.OverlapSphere(transform.position, 2f); // Detección de objetos cercanos
        foreach (Collider obj in objects)
        {
            if (obj.CompareTag("Pickable"))
            {
                heldObject = obj.gameObject;
                heldObject.transform.SetParent(hand); // Lo asignamos a la mano
                heldObject.transform.localPosition = Vector3.zero; // Lo alineamos
                heldObject.transform.localRotation = Quaternion.identity; // Lo rotamos bien
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Desactiva la física para que no caiga
                Debug.Log("Objeto recogido: " + heldObject.name);
                return; // Salimos después de recoger el primer objeto
            }
        }
    }

    void DropObject()
    {
        heldObject.transform.SetParent(null); // Lo soltamos
        heldObject.GetComponent<Rigidbody>().isKinematic = false; // Reactiva la física
        heldObject = null; // Ya no hay objeto en la mano
        Debug.Log("Objeto soltado.");
    }
}