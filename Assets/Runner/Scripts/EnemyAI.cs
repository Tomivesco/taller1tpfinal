using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnemyAI : MonoBehaviour
{
   

    [Header("Configuración de comportamiento")]
    [SerializeField] private float speed = 3.0f;

    [Header("Configuración de estadísticas")]
    [SerializeField] private int dmg = 1;
    [SerializeField] private int life = 1;
    public float score = 10f;

    [SerializeField] private Configuracion_General config;



//private Animator animator;
    [SerializeField] private Transform radioDeColision;



    [SerializeField] private GameObject efectomuerte;


    private void Awake()
    {
        GameObject gm = GameObject.FindWithTag("GameController");

        if (gm != null)
        {
            config = gm.GetComponent<Configuracion_General>();

        }

    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Movement();
    }





    private void Start()
    {
        //animator = GetComponent<Animator>();
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





    private void Movement()
    {

        if (Configuracion_General.runner3D == false)
        {
            if (transform.position.y >= -6.0f)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else
            {
                destroyMe();
            }
        }else
        {
            if (transform.position.z >= -6.0f)
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            else
            {
                destroyMe();
            }
        }

    }

    public void Damage(int _dmg)
    {
        if (life > 0)
        {
            life -= _dmg;
            if (life <= 0)
            {
                destroyMe();
                giveScore(score);
               
            }
        }
        else if (life <= 0)
        {
            destroyMe();
        }
    }

   

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) 
        {
            life -= 1;
        }
    }



    void OnTriggerEnter(Collider other)
    {
      /*  if (collision.CompareTag("Player")) // Verifica la etiqueta del jugador
        {
            life -= 1;
        }*/
    


        // Si el enemigo choca con el jugador
        if (other.gameObject.tag == "Player")
        {
            gamemanager.Instance.PerderVida();
           

            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Te choque");
                player.Damage(dmg);
                life--;
            }

            if (life <= 0)
            {
                destroyMe();
            }

        }
        else if (other.gameObject.tag == "Bullet")
        {

            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                Damage(bullet.dmg);
                Destroy(other.gameObject);
            }

        }
        
}

    private void giveScore (float _score)
    {
        if (config != null)
        {
            Debug.Log("SUMA PUNTO");
            config.puntos += _score;
        }else
        {
            Debug.Log("No hay un Script de configuracion general asignado");
        }
        
    }

    private void destroyMe ()
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
    public void TomarDaño(float daño)
    {
        life -= dmg;
        if (life <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        // Agrega aquí cualquier lógica adicional para cuando el enemigo muere
       // animator.SetTrigger("muerte");
        //animator.SetBool("muerte");
       // Destroy(gameObject); // O desactiva el objeto, según tus necesidades

        Instantiate(efectomuerte, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
