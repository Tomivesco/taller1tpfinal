using UnityEngine;
using UnityEngine.UI;

public class ControlBarraProgreso : MonoBehaviour
{
    public Slider barraDeProgreso;
    public Transform player;
    public Transform meta;
    public float distanciaMaxima = 10f; // La distancia máxima entre el jugador y la meta.

    private RectTransform barraTransform;

    private void Start()
    {
        barraTransform = barraDeProgreso.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (player != null && meta != null)
        {
            float distancia = Vector3.Distance (player.position, meta.position);
            float porcentajeProgreso = 10 - (distancia / distanciaMaxima);
            porcentajeProgreso = Mathf.Clamp01(porcentajeProgreso);
            barraDeProgreso.value = porcentajeProgreso;

            // Ajusta la posición de la barra de progreso.
            float posX = Mathf.Lerp(player.position.x, meta.position.x, porcentajeProgreso);
            barraTransform.position = new Vector3(posX, barraTransform.position.y, barraTransform.position.z);
        }
    }
}


