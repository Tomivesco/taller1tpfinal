using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public static gamemanager Instance { get; private set; }
    private int vidas = 3;
    public HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("cuidado! mas de un gamemanager en escena.");
        }
    }

    public void PerderVida()
    {
        vidas -= 1;
        hud.DesactivarVida(vidas);
    }
}
