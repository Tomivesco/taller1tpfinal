using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDePeligro : MonoBehaviour {


    public GameObject imagenDeAlerta; // Arrastra aqu� la imagen de alerta en el inspector.
    public float distanciaMinima = 5f;
    public Transform enemigo; // Arrastra el objeto del enemigo aqu�.

    void Update()
    {
        // Calcula la distancia entre el jugador y el enemigo.
        float distanciaAlEnemigo = Vector3.Distance(transform.position, enemigo.position);

        // Comprueba si el enemigo est� dentro de la distancia m�nima.
        if (distanciaAlEnemigo < distanciaMinima)
        {
            imagenDeAlerta.SetActive(true);
        }
        else
        {
            imagenDeAlerta.SetActive(false);
        }
    }
}



