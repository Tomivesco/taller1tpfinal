using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class disparojugador : MonoBehaviour
{

    [SerializeField] private Transform controladordisparo;
    [SerializeField] private GameObject bala;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            disparar();
        }
    }

    private void disparar()
    {
        Instantiate(bala,controladordisparo.position,controladordisparo.rotation);
    }




}
 