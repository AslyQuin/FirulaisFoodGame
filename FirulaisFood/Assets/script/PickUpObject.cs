using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform hand; // Mano del jugador
    private GameObject heldObject = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickUp();
            }
            else
            {
                DropObject();
            }
        }
    }

    void TryPickUp()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider obj in objects)
        {
            if (obj.CompareTag("Pickable"))
            {
                heldObject = obj.gameObject;
                heldObject.transform.SetParent(hand);
                heldObject.transform.localPosition = Vector3.zero;
                heldObject.transform.localRotation = Quaternion.identity;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;

                Debug.Log("Objeto recogido: " + heldObject.name);

                InterfazControl ui = FindFirstObjectByType<InterfazControl>();
                if (ui != null)
                {
                    ui.TacharSprite(heldObject.name);
                }

                return;
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