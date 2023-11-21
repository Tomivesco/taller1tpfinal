using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionrayo: MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Aqu� es donde manejar�as la colisi�n entre el jugador y el enemigo
            // Por ejemplo, puedes destruir al enemigo despu�s de la colisi�n.
            Debug.Log("�Colisi�n con el enemigo!");
            Destroy(collision.gameObject); // Esto eliminar� el GameObject del enemigo
        }
    }
}
