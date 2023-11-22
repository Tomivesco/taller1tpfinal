using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float da�o;
    private void Update()
    {
        transform.Translate(Vector2.right * velocidad* Time.deltaTime); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAI>().TomarDa�o(da�o);
        Destroy(gameObject);
        }
    }
}
