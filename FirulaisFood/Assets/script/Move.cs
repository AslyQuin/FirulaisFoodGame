using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float moveSpeed = 10f;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float xValue = -Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = -Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // Vector de movimiento original
        Vector3 movementDirection = new Vector3(xValue, 0f, zValue);

        if (movementDirection.magnitude > 0.01f) // Verifica si el personaje se está moviendo
        {
            // Rotar el movimiento 45° a la derecha
            movementDirection = Quaternion.Euler(0, 45, 0) * movementDirection;

            // Aplicar la rotación al personaje
            transform.rotation = Quaternion.LookRotation(movementDirection);
        }

        // Mover al personaje con la nueva dirección rotada
        transform.Translate(movementDirection, Space.World);
    }
}
