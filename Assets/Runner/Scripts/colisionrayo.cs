using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionrayo: MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Aquí es donde manejarías la colisión entre el jugador y el enemigo
            // Por ejemplo, puedes destruir al enemigo después de la colisión.
            Debug.Log("¡Colisión con el enemigo!");
            Destroy(collision.gameObject); // Esto eliminará el GameObject del enemigo
        }
    }
}
