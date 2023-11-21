using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{
    Camera m_MainCamera;
    void Start()
    {
     m_MainCamera=Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
     m_MainCamera.transform.position=new Vector3(0,transform.position.y,transform.position.z);

    }
}
