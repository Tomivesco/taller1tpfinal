using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraprueba : MonoBehaviour

{
    [SerializeField] Transform Player;
    [SerializeField] Transform endline;
    [SerializeField] Slider slider;

    float maxDistance;

    private void Start()
    {
        maxDistance = getDistance();
    }

    private void Update()
    {
        // if (Player.position.y <= maxDistance && Player.position.y <= endline.position.y)
        if (Player.position.y <= endline.position.y)
        {
            float distance = 1 - (getDistance() / maxDistance);
            setProgress(distance);
        }
    }

    float getDistance()
    {
        return Vector3.Distance(Player.position, endline.position);
    }

    void setProgress(float p)
    {
        slider.value = p;
    }

}


   


    



