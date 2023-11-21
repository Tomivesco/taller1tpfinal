using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatcac : MonoBehaviour
{
    public static event Action<Vector2, float> OnGolpeRealizado; // Evento que se activar� cuando se realice un golpe

    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private int da�oGolpe;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Golpe();
        }
    }

    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<EnemyAI>().TomarDa�o(da�oGolpe);

                // Disparar el evento OnGolpeRealizado
                OnGolpeRealizado.Invoke(colisionador.transform.position, da�oGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}