using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraprueba : MonoBehaviour

{
    public Slider barraDeProgreso;
    public Transform player;

    private RectTransform barraTransform;

    private void Start()
    {
        barraTransform = barraDeProgreso.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (player != null)
        {
            // Ajusta la posición de la barra de progreso según la posición del jugador.
            barraTransform.position = Camera.main.WorldToScreenPoint(player.position);
        }
    }
}

