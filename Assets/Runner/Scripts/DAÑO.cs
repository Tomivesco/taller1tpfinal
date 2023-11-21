using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAÑO : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;

    [SerializeField] private Transform radioDeColision;

    void Start()
    {
        animator = GetComponent<Animator>();
        combatcac.OnGolpeRealizado += HandleGolpeRealizado;
    }

    private void HandleGolpeRealizado(Vector2 posicion, float daño)
    {
        float distancia = Vector2.Distance(transform.position, posicion);

        // Verificar si la posición del golpe está dentro del rango de colisión del objeto
        if (distancia < radioDeColision.localScale.x / 2f) // Considerando un objeto circular
        {
            TomarDaño(daño);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica la etiqueta del jugador
        {
            vida -= 1;
        }
    }

    private void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        // Agrega aquí cualquier lógica adicional para cuando el enemigo muere
        animator.SetTrigger("muerte");
        //animator.SetBool("muerte");
        Destroy(gameObject); // O desactiva el objeto, según tus necesidades
        
    }
}