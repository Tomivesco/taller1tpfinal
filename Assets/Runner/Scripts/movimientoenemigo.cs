using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MovimientoEnemigo : MonoBehaviour
{
    [SerializeField] private int dmg = 1;
    [SerializeField] private int life = 1;

    public float velocidad = 5.0f; // Velocidad de movimiento del enemigo.
    public Transform carril; // El carril en el que se moverá el enemigo.

    
    public Transform lineaDelJugador; // Referencia al objeto que representa la línea del jugador.

  

    void Update()
    {
        
            // Mover el enemigo hacia adelante en el carril.
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            
  }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gamemanager.Instance.PerderVida();


            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Te choque");
                player.Damage(dmg);
                life--;
                Destroy(gameObject);
            }

            if (life <= 0)
            {
               
                Destroy(gameObject);
            }
            if (other.CompareTag("lineaDelJugador")) // Asegúrate de que el tag coincida con los enemigos
            {
                
                Destroy(gameObject); // Elimina el enemigo cuando colisiona con el collider del jugador.
            }
             }
    }
     private void destroyMe()
     {
         if (SpawnManager.activeEnemies.Count > 0)
         {
             for (int i = 0; i < SpawnManager.activeEnemies.Count; i++)
             {
                 if (SpawnManager.activeEnemies[i].transform.position == this.gameObject.transform.position)
                 {
                     SpawnManager.activeEnemies.Remove(SpawnManager.activeEnemies[i]);
                     Destroy(this.gameObject);
                     break;
                    

                }
             }

         }
     }

     
 
    }


