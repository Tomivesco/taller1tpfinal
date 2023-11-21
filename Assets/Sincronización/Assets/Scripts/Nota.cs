using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nota : MonoBehaviour {

    public Configuracion_General config;
    Rigidbody2D rb;
    //Esta variable nos va a indicar la velocidad con la que se va a mover en el eje y, osea que tan rapido va a "caer".
    //Hacemos esta variable publica para poder setearla desde el inspector de la nota
    public float velocidad;
    //Esta booleana la vamos a usar para asegurarnos que se llama una sola vez
    bool called = false;

   

    void Awake()
    {
        velocidad = config.velocidad;
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        //Esto lo hacemos para asegurarnos que las notas empiecen a moverse junto con la musica. 
        //Como necesitamos que la velocidad se sume una sola vez agragamos esta variable "called".
        if ( PlayerPrefs.GetInt("Start") == 1 && !called)
        {
            rb.velocity = new Vector2(0, -velocidad);
        }
    }

}
