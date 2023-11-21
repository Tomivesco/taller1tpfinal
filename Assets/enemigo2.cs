using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            gamemanager.Instance.PerderVida();
        }
    }
    
        
    
}
