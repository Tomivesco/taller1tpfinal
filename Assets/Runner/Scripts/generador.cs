using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public Transform[] carriles;
    public float tiempoEntreGeneracion = 2.0f;

   

    private float tiempoUltimaGeneracion;

    void Start()
    {
        tiempoUltimaGeneracion = Time.time;
    }


    void Update()
    {
        if (Time.time - tiempoUltimaGeneracion > tiempoEntreGeneracion)
        {
            GenerarEnemigo();
            tiempoUltimaGeneracion = Time.time;
        }
          
        }

    void GenerarEnemigo()
    {
        int carrilAleatorio = Random.Range(0, carriles.Length);

        Vector3 posicionGeneracion = carriles[carrilAleatorio].position;

        posicionGeneracion.z = -10; // Asegúrate de que aparezcan detrás del jugador

        Instantiate(enemigoPrefab, posicionGeneracion, Quaternion.identity);
    }
    
}

