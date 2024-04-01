using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public GameObject Fox;

    void Update()
    {
        if(Fox !=null)
        {
            Vector3 position = transform.position;
            position.x = Fox.transform.position.x;
            transform.position = position;
        }
    }
}
